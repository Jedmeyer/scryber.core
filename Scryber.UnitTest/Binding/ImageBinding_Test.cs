﻿using System;
using System.IO;
using System.Net.WebSockets;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Scryber.Components;
using Scryber.Drawing;
using Scryber.PDF;

namespace Scryber.Core.UnitTests.Binding
{
    [TestClass()]
    public class ImageBinding_Test
    {

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }


        public ImageBinding_Test()
        {
        }

        [TestMethod]
        public void ImagePathParamerterBinding()
        {

            var pdfx = @"<?xml version='1.0' encoding='utf-8' ?>
<doc:Document xmlns:doc='http://www.scryber.co.uk/schemas/core/release/v1/Scryber.Components.xsd'
              xmlns:styles='http://www.scryber.co.uk/schemas/core/release/v1/Scryber.Styles.xsd'
              xmlns:data='http://www.scryber.co.uk/schemas/core/release/v1/Scryber.Data.xsd' >
  <Params>
    <doc:Object-Param id='MyImage' />
  </Params>
  <Pages>

    <doc:Page styles:margins='20pt'>
      <Content>
        <doc:Image id='LoadedImage' img-data='{@:MyImage}' />
        
      </Content>
    </doc:Page>
  </Pages>

</doc:Document>";

            using (var reader = new System.IO.StringReader(pdfx))
            {
                var doc = Document.ParseDocument(reader, ParseSourceType.DynamicContent);

                var path = this.TestContext.TestDir;

#if MAC_OS
                // back up from obj/Debug/TestDirectoryName
                path = System.IO.Path.Combine(path, "../../../Content/HTML/Images/Toroid24.jpg");
#else
                path = System.IO.Path.Combine(path, "../../Scryber.Core.UnitTest/Content/HTML/Images/Toroid24.jpg"); ;
#endif

                path = System.IO.Path.GetFullPath(path);

                var imgReader = Scryber.Imaging.ImageReader.Create();
                ImageData data;
                
                using (var fs = new System.IO.FileStream(path, FileMode.Open))
                {
                    data = imgReader.ReadStream(path, fs, false);
                }
                
                
                doc.Params["MyImage"] = data;

                var img = doc.FindAComponentById("LoadedImage") as Image;
                Assert.IsNotNull(img);
                Assert.IsNull(img.Data);

                doc.InitializeAndLoad(OutputFormat.PDF);
                doc.DataBind(OutputFormat.PDF);
                
                Assert.IsNotNull(img.Data);
                Assert.AreEqual(data, img.Data);

            }
        }

        [TestMethod()]
        public void ImageDataParameterBinding()
        {
            var path = this.TestContext.TestDir;

#if MAC_OS
            // back up from obj/Debug/TestDirectoryName
            path = System.IO.Path.Combine(path, "../../../Content/HTML/Images/");
#else
            path = System.IO.Path.Combine(path, "../../Scryber.Core.UnitTest/Content/HTML/Images/"); ;
#endif

            path = System.IO.Path.GetFullPath(path);
            if (!path.EndsWith("/"))
                path += "/";

            var imgReader = Scryber.Imaging.ImageReader.Create();
            ImageData data1, data2;
                
            using (var fs = new System.IO.FileStream(path + "Toroid24.jpg", FileMode.Open))
            {
                data1 = imgReader.ReadStream(path, fs, false);
            }
            
            using (var fs = new System.IO.FileStream(path + "group.png", FileMode.Open))
            {
                data2 = imgReader.ReadStream(path, fs, false);
            }
            
            var model = new
            {
                img1 = data1,
                img2 = data2
            };


            var content = @"<?xml version='1.0' encoding='utf-8' ?>
<doc:Document xmlns:doc='http://www.scryber.co.uk/schemas/core/release/v1/Scryber.Components.xsd'
              xmlns:styles='http://www.scryber.co.uk/schemas/core/release/v1/Scryber.Styles.xsd'
              xmlns:data='http://www.scryber.co.uk/schemas/core/release/v1/Scryber.Data.xsd' >
  <Params>
    <doc:Object-Param id='model' />
  </Params>
  <Pages>

    <doc:Section styles:margins='20pt'>
      <Content>
        
        <doc:Image id='LoadedImage1' img-data='{{model.img1}}' />
        <doc:PageBreak/>
        <doc:Image id='LoadedImage2' img-data='{{model.img2}}' />
      </Content>
    </doc:Section>

  </Pages>

</doc:Document>";

            Document doc;
            using (var reader = new System.IO.StringReader(content))
            {
                doc = Document.ParseDocument(reader, ParseSourceType.DynamicContent);
            }

            doc.Params["model"] = model;
            doc.LayoutComplete += Doc_LayoutComplete;

            using (var stream = DocStreams.GetOutputStream("DataImageOutput.pdf"))
            {
                doc.SaveAsPDF(stream);
            }

            var found1 = doc.FindAComponentById("LoadedImage1") as Image;
            var found2 = doc.FindAComponentById("LoadedImage2") as Image;
            Assert.IsNotNull(found1);
            Assert.IsNotNull(found1.Data);
            Assert.AreEqual(data1, found1.Data);

            Assert.IsNotNull(found2);
            Assert.IsNotNull(found2.Data);
            Assert.AreEqual(data2, found2.Data);
            
        }

        private void Doc_LayoutComplete(object sender, LayoutEventArgs args)
        {
            var context = (PDFLayoutContext)(args.Context);

            var layoutPg = context.DocumentLayout.AllPages[0];
            var layoutLine1 = layoutPg.ContentBlock.Columns[0].Contents[0] as Scryber.PDF.Layout.PDFLayoutLine;

            Assert.IsNotNull(layoutLine1);
            Assert.AreEqual(1, layoutLine1.Runs.Count);

            var compRun1 = layoutLine1.Runs[0] as Scryber.PDF.Layout.PDFLayoutComponentRun;
            Assert.IsNotNull(compRun1);

            Assert.IsNotNull(compRun1.Owner);
            Assert.AreEqual("LoadedImage1", compRun1.Owner.ID);

            layoutPg = context.DocumentLayout.AllPages[1];
            var layoutLine2 = layoutPg.ContentBlock.Columns[0].Contents[0] as Scryber.PDF.Layout.PDFLayoutLine;

            Assert.IsNotNull(layoutLine2);
            Assert.AreEqual(1, layoutLine2.Runs.Count);

            var compRun2= layoutLine2.Runs[0] as Scryber.PDF.Layout.PDFLayoutComponentRun;
            Assert.IsNotNull(compRun2);

            Assert.IsNotNull(compRun2.Owner);
            Assert.AreEqual("LoadedImage2", compRun2.Owner.ID);
            

        }
    }
}

﻿/*  Copyright 2012 PerceiveIT Limited
 *  This file is part of the Scryber library.
 *
 *  You can redistribute Scryber and/or modify 
 *  it under the terms of the GNU Lesser General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 * 
 *  Scryber is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU Lesser General Public License for more details.
 * 
 *  You should have received a copy of the GNU Lesser General Public License
 *  along with Scryber source code in the COPYING.txt file.  If not, see <http://www.gnu.org/licenses/>.
 * 
 */

#define LOCALSTYLEITEMS //If declared then references to the local style items will be stored as variables in the instance

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scryber;
using Scryber.Drawing;
using System.ComponentModel;
using Scryber.Styles.Parsing;

namespace Scryber.Styles
{
    /// <summary>
    /// Concrete implementation of a Style containing properties for accessing 
    /// each of the Style Items where values can be read or set.
    /// </summary>
    [PDFParsableValue()]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class PDFStyle : PDFStyleBase, IPDFBindableComponent
    {
        #region public const string PDFStylesNamespace

        /// <summary>
        /// The fully qualified assemblynamespace
        /// </summary>
        public const string PDFStylesNamespace = "Scryber.Styles, Scryber.Styles, Version=1.0.0.0, Culture=neutral, PublicKeyToken=872cbeb81db952fe";

        #endregion

        // events

        #region public event PDFDataBindEventHandler DataBinding + OnDataBinding(args)

        [PDFAttribute("on-databinding")]
        public event PDFDataBindEventHandler DataBinding;

        protected virtual void OnDataBinding(PDFDataContext context)
        {
            if (this.DataBinding != null)
                this.DataBinding(this, new PDFDataBindEventArgs(context));
        }

        #endregion

        #region public event PDFDataBindEventHandler DataBound + OnDataBound(args)

        [PDFAttribute("on-databound")]
        public event PDFDataBindEventHandler DataBound;

        protected virtual void OnDataBound(PDFDataContext context)
        {
            if (this.DataBound != null)
                this.DataBound(this, new PDFDataBindEventArgs(context));
        }

        #endregion


        #region public string ID {get;set;}

        private string _id;

        /// <summary>
        /// Gets or sets the ID for this instance
        /// </summary>
        [PDFAttribute("id")]
        public string ID
        {
            get
            {
                if (String.IsNullOrEmpty(_id))
                {
                    _id = string.Empty;
                }
                return this._id;
            }
            set
            {
                _id = value;
            }
        }

        #endregion

        // style accessort properties

        #region public PDFBackgroundStyle Background {get;}

#if LOCALSTYLEITEMS

        private PDFBackgroundStyle _bg;

        /// <summary>
        /// Gets the background associated with this Style
        /// </summary>
        public PDFBackgroundStyle Background
        {
            get
            {

                if (null == _bg)
                    _bg = this.GetOrCreateItem<PDFBackgroundStyle>(PDFStyleKeys.BgItemKey);

                return _bg;
            }
        }
#else
        /// <summary>
        /// Gets the background associated with this Style
        /// </summary>
        public PDFBackgroundStyle Background
        {
            get
            {
                return this.GetOrCreateItem<PDFBackgroundStyle>(PDFStyleKeys.BgItemKey);
            }
        }
#endif
        #endregion

        #region public PDFPaddingStyle Padding {get;}

#if LOCALSTYLEITEMS
        private PDFPaddingStyle _padding;

        /// <summary>
        /// Gets the padding associated with this Style
        /// </summary>
        public PDFPaddingStyle Padding
        {
            get
            {

                if (null == _padding)
                    _padding = this.GetOrCreateItem<PDFPaddingStyle>(PDFStyleKeys.PaddingItemKey);
                
                return _padding;
            }
        }
#else
        /// <summary>
        /// Gets the padding associated with this Style
        /// </summary>
        public PDFPaddingStyle Padding
        {
            get
            {
                return this.GetOrCreateItem<PDFPaddingStyle>(PDFStyleKeys.PaddingItemKey);
            }
        }
#endif
        #endregion

        #region public PDFMarginsStyle Margins {get;}

#if LOCALSTYLEITEMS

        private PDFMarginsStyle _margins;

        /// <summary>
        /// Gets the margins associated with this Style
        /// </summary>
        public PDFMarginsStyle Margins
        {
            get
            {
                if (null == _margins)
                {
                    _margins = this.GetOrCreateItem<PDFMarginsStyle>(PDFStyleKeys.MarginsItemKey);
                }
                return _margins;
            }
        }
#else
        /// <summary>
        /// Gets the margins associated with this Style
        /// </summary>
        public PDFMarginsStyle Margins
        {
            get
            {
                return this.GetOrCreateItem<PDFMarginsStyle>(PDFStyleKeys.MarginsItemKey);
            }
        }

#endif

        #endregion

        #region public PDFFontStyle Font {get;}

#if LOCALSTYLEITEMS

        private PDFFontStyle _font;

        /// <summary>
        /// Gets the Font information associated with this style
        /// </summary>
        public PDFFontStyle Font
        {
            get
            {
                if (null == _font)
                {
                    _font = this.GetOrCreateItem<PDFFontStyle>(PDFStyleKeys.FontItemKey);
                }
                return _font;
            }
        }

#else
        public PDFFontStyle Font
        {
            get
            {
                return this.GetOrCreateItem<PDFFontStyle>(PDFStyleKeys.FontItemKey);
            }
        }
#endif

        #endregion

        #region public PDFFillStyle Fill {get;}

#if LOCALSTYLEITEMS

        private PDFFillStyle _fill;

        /// <summary>
        /// Gets the fill associated with this Style
        /// </summary>
        public PDFFillStyle Fill
        {
            get
            {

                if (null == _fill)
                    _fill = this.GetOrCreateItem<PDFFillStyle>(PDFStyleKeys.FillItemKey);

                return _fill;
            }
        }
#else
        /// <summary>
        /// Gets the fill associated with this Style
        /// </summary>
        public PDFFillStyle Fill
        {
            get
            {
                return this.GetOrCreateItem<PDFFillStyle>(PDFStyleKeys.FillItemKey);
            }
        }
#endif
        #endregion

        #region public PDFColumnsStyle Columns {get;}

#if LOCALSTYLEITEMS

        private PDFColumnsStyle _cols;

        /// <summary>
        /// Gets the Column info associated with this style
        /// </summary>
        public PDFColumnsStyle Columns
        {
            get
            {
                if (null == _cols)
                {
                    _cols = this.GetOrCreateItem<PDFColumnsStyle>(PDFStyleKeys.ColumnItemKey);
                }
                return _cols;
            }
        }

#else
        /// <summary>
        /// Gets the Column info associated with this style
        /// </summary>
        public PDFColumnsStyle Columns
        {
            get
            {
                return this.GetOrCreateItem<PDFColumnsStyle>(PDFStyleKeys.ColumnItemKey);
            }
        }
#endif

        #endregion

        #region public PDFOverflowStyle Overflow {get;}

#if LOCALSTYLEITEMS

        private PDFOverflowStyle _over;

        /// <summary>
        /// Gets the Overflow info associated with this Style
        /// </summary>
        public PDFOverflowStyle Overflow
        {
            get
            {
                if (null == _over)
                {
                    _over = this.GetOrCreateItem<PDFOverflowStyle>(PDFStyleKeys.OverflowItemKey);
                }
                return _over;
            }
        }

#else
        /// <summary>
        /// Gets the Overflow info associated with this Style
        /// </summary>
        public PDFOverflowStyle Overflow
        {
            get
            {
                return this.GetOrCreateItem<PDFOverflowStyle>(PDFStyleKeys.OverflowItemKey);
            }
        }
#endif

        #endregion

        #region public PDFPositionStyle Position {get;}

#if LOCALSTYLEITEMS

        private PDFPositionStyle _pos;

        /// <summary>
        /// Gets or sets the position info associated with this style
        /// </summary>
        public PDFPositionStyle Position
        {
            get
            {
                if (null == _pos)
                {
                    _pos = this.GetOrCreateItem<PDFPositionStyle>(PDFStyleKeys.PositionItemKey);
                }
                return _pos;
            }
        }

#else
        /// <summary>
        /// Gets or sets the position info associated with this style
        /// </summary>
        public PDFPositionStyle Position
        {
            get
            {
                return this.GetOrCreateItem<PDFPositionStyle>(PDFStyleKeys.PositionItemKey);
            }
        }
#endif

        #endregion

        #region public PDFSizeStyle Size {get;}

#if LOCALSTYLEITEMS

        private PDFSizeStyle _sz;

        /// <summary>
        /// Gets or sets the size info associated with this style
        /// </summary>
        public PDFSizeStyle Size
        {
            get
            {
                if (null == _sz)
                {
                    _sz = this.GetOrCreateItem<PDFSizeStyle>(PDFStyleKeys.SizeItemKey);
                }
                return _sz;
            }
        }

#else
        /// <summary>
        /// Gets or sets the size info associated with this style
        /// </summary>
        public PDFSizeStyle Size
        {
            get
            {
                return this.GetOrCreateItem<PDFSizeStyle>(PDFStyleKeys.SizeItemKey);
            }
        }
#endif

        #endregion

        #region public PDFClipStyle Clipping {get;}

#if LOCALSTYLEITEMS

        private PDFClipStyle _clip;

        /// <summary>
        /// Gets the Clipping info associated with this style
        /// </summary>
        public PDFClipStyle Clipping
        {
            get
            {
                if (null == _clip)
                {
                    _clip = this.GetOrCreateItem<PDFClipStyle>(PDFStyleKeys.ClipItemKey);
                }
                return _clip;
            }
        }

#else
        /// <summary>
        /// Gets the Clipping info associated with this style
        /// </summary>
        public PDFClipStyle Clipping
        {
            get
            {
                return  this.GetOrCreateItem<PDFClipStyle>(PDFStyleKeys.ClipItemKey);
            }
        }
#endif

        #endregion

        #region public PDFBorderStyle Border {get;}

#if LOCALSTYLEITEMS

        private PDFBorderStyle _border;

        /// <summary>
        /// Gets the border associated with this Style
        /// </summary>
        public PDFBorderStyle Border
        {
            get
            {

                if (null == _border)
                    _border = this.GetOrCreateItem<PDFBorderStyle>(PDFStyleKeys.BorderItemKey);

                return _border;
            }
        }
#else
        /// <summary>
        /// Gets the border associated with this Style
        /// </summary>
        public PDFBorderStyle Border
        {
            get
            {
                return this.GetOrCreateItem<PDFBorderStyle>(PDFStyleKeys.BorderItemKey);
            }
        }
#endif
        #endregion

        #region public PDFStrokeStyle Stroke {get;}

#if LOCALSTYLEITEMS

        private PDFStrokeStyle _stroke;

        /// <summary>
        /// Gets the stroke style item associated with this Style
        /// </summary>
        public PDFStrokeStyle Stroke
        {
            get
            {

                if (null == _stroke)
                    _stroke = this.GetOrCreateItem<PDFStrokeStyle>(PDFStyleKeys.StrokeItemKey);

                return _stroke;
            }
        }
#else
        /// <summary>
        /// Gets the stroke style item associated with this Style
        /// </summary>
        public PDFStrokeStyle Stroke
        {
            get
            {
                return this.GetOrCreateItem<PDFStrokeStyle>(PDFStyleKeys.StrokeItemKey);
            }
        }
#endif
        #endregion

        #region public PDFTextStyle Text {get;}

#if LOCALSTYLEITEMS

        private PDFTextStyle _text;

        /// <summary>
        /// Gets the text style item associated  with this Style
        /// </summary>
        public PDFTextStyle Text
        {
            get
            {

                if (null == _text)
                    _text = this.GetOrCreateItem<PDFTextStyle>(PDFStyleKeys.TextItemKey);

                return _text;
            }
        }
#else
        /// <summary>
        /// Gets the background associated with this Style
        /// </summary>
        public PDFTextStyle Text
        {
            get
            {
                return this.GetOrCreateItem<PDFTextStyle>(PDFStyleKeys.TextItemKey);
            }
        }
#endif
        #endregion

        #region public PDFListStyle List {get;}

#if LOCALSTYLEITEMS

        private PDFListStyle _list;

        /// <summary>
        /// Gets the list style item associated  with this Style
        /// </summary>
        public PDFListStyle List
        {
            get
            {

                if (null == _list)
                    _list = this.GetOrCreateItem<PDFListStyle>(PDFStyleKeys.ListItemKey);

                return _list;
            }
        }
#else
        /// <summary>
        /// Gets the list style item associated with this Style
        /// </summary>
        public PDFListStyle List
        {
            get
            {
                return this.GetOrCreateItem<PDFListStyle>(PDFStyleKeys.ListItemKey);
            }
        }
#endif
        #endregion

        #region public PDFModifyPageStyle PageModifications {get;}

#if LOCALSTYLEITEMS

        private PDFModifyPageStyle _modify;

        /// <summary>
        /// Gets the ModifyPage style item associated with this Style
        /// </summary>
        public PDFModifyPageStyle PageModifications
        {
            get
            {

                if (null == _modify)
                    _modify = this.GetOrCreateItem<PDFModifyPageStyle>(PDFStyleKeys.ModifyPageItemKey);

                return _modify;
            }
        }

#else

        /// <summary>
        /// Gets the ModifyPage style item associated with this Style
        /// </summary>
        public PDFModifyPageStyle PageModifications
        {
            get
            {
                return this.GetOrCreateItem<PDFModifyPageStyle>(PDFStyleKeys.ModifyPageItemKey);
            }
        }

#endif

        #endregion

        #region public PDFOutlineStyle Outline {get;}

#if LOCALSTYLEITEMS

        private PDFOutlineStyle _outline;

        /// <summary>
        /// Gets the outline style item associated  with this Style
        /// </summary>
        public PDFOutlineStyle Outline
        {
            get
            {

                if (null == _outline)
                    _outline = this.GetOrCreateItem<PDFOutlineStyle>(PDFStyleKeys.OutlineItemKey);

                return _outline;
            }
        }
#else
        /// <summary>
        /// Gets the outline style item associated with this Style
        /// </summary>
        public PDFOutlineStyle Outline
        {
            get
            {
                return this.GetOrCreateItem<PDFOutlineStyle>(PDFStyleKeys.OutlineItemKey);
            }
        }
#endif

        #endregion

        #region public PDFOverlayGridStyle OverlayGrid {get;}

#if LOCALSTYLEITEMS

        private PDFOverlayGridStyle _overlay;

        /// <summary>
        /// Gets the Overlay Grid style item associated  with this Style
        /// </summary>
        public PDFOverlayGridStyle OverlayGrid
        {
            get
            {

                if (null == _overlay)
                    _overlay = this.GetOrCreateItem<PDFOverlayGridStyle>(PDFStyleKeys.OverlayItemKey);

                return _overlay;
            }
        }
#else
        /// <summary>
        /// Gets the Overlay Grid style item associated with this Style
        /// </summary>
        public PDFOverlayGridStyle OverlayGrid
        {
            get
            {
                return this.GetOrCreateItem<PDFOverlayGridStyle>(PDFStyleKeys.OverlayItemKey);
            }
        }
#endif

        #endregion

        #region public PDFPageStyle PageStyle {get;}

#if LOCALSTYLEITEMS

        private PDFPageStyle _pg;

        /// <summary>
        /// Gets the page style item associated  with this Style
        /// </summary>
        public PDFPageStyle PageStyle
        {
            get
            {

                if (null == _pg)
                    _pg = this.GetOrCreateItem<PDFPageStyle>(PDFStyleKeys.PageItemKey);

                return _pg;
            }
        }

#else

        /// <summary>
        /// Gets the page style item associated with this Style
        /// </summary>
        public PDFPageStyle PageStyle
        {
            get
            {
                return this.GetOrCreateItem<PDFPageStyle>(PDFStyleKeys.PageItemKey);
            }
        }

#endif

        #endregion

        #region public PDFShapeStyle Shape {get;}

#if LOCALSTYLEITEMS

        private PDFShapeStyle _shape;

        /// <summary>
        /// Gets the shape style item associated  with this Style
        /// </summary>
        public PDFShapeStyle Shape
        {
            get
            {

                if (null == _shape)
                    _shape = this.GetOrCreateItem<PDFShapeStyle>(PDFStyleKeys.ShapeItemKey);

                return _shape;
            }
        }

#else

        /// <summary>
        /// Gets the shape style item associated with this Style
        /// </summary>
        public PDFShapeStyle Shape
        {
            get
            {
                return this.GetOrCreateItem<PDFShapeStyle>(PDFStyleKeys.ShapeItemKey);
            }
        }

#endif

        #endregion

        #region public PDFTableStyle Table {get;}

#if LOCALSTYLEITEMS

        private PDFTableStyle _table;

        /// <summary>
        /// Gets the Table style item associated  with this Style
        /// </summary>
        public PDFTableStyle Table
        {
            get
            {

                if (null == _table)
                    _table = this.GetOrCreateItem<PDFTableStyle>(PDFStyleKeys.TableItemKey);

                return _table;
            }
        }

#else

        /// <summary>
        /// Gets the Table style item associated with this Style
        /// </summary>
        public PDFTableStyle Table
        {
            get
            {
                return this.GetOrCreateItem<PDFTableStyle>(PDFStyleKeys.TableItemKey);
            }
        }

#endif

        #endregion

        #region public PDFTransformStyle Transform {get;}

        //Transformations are not currently suported.

#if USETRANSFORM

#if LOCALSTYLEITEMS

        private PDFTransformStyle _transform;

        /// <summary>
        /// Gets the Transform style item associated  with this Style
        /// </summary>
        public PDFTransformStyle Transform
        {
            get
            {

                if (null == _transform)
                    _transform = this.GetOrCreateItem<PDFTransformStyle>(PDFStyleKeys.TransformItemKey);

                return _transform;
            }
        }

#else

        /// <summary>
        /// Gets the Transform style item associated with this Style
        /// </summary>
        public PDFTransformStyle Transform
        {
            get
            {
                return this.GetOrCreateItem<PDFTransformStyle>(PDFStyleKeys.TransformItemKey);
            }
        }

#endif

#endif

#endregion

        // Items override

        #region public override PDFStyleItemCollection Items {get;}

        [PDFElement("")]
        [PDFArray(typeof(PDFStyleItemBase))]
        public override PDFStyleItemCollection StyleItems
        {
            get
            {
                return base.StyleItems;
            }
        }

        #endregion

        #region public PDFStyleCollection InnerStyles {get;}

        private PDFStyleCollection _inner;

        [PDFElement("Inner-Styles")]
        [PDFArray()]
        public PDFStyleCollection InnerStyles
        {
            get
            {
                if (this._inner == null)
                    this._inner = CreateInnerStyleCollection();
                return _inner;
            }
            set
            {
                this._inner = value;
            }
        }

        public bool HasInnerStyles
        {
            get
            {
                if (null == _inner || _inner.Count == 0)
                    return false;
                else
                    return true;
            }
        }

        protected virtual PDFStyleCollection CreateInnerStyleCollection()
        {
            return new PDFStyleCollection();
        }

        #endregion

        //
        // .ctors
        //

        public PDFStyle()
            : this(PDFObjectTypes.Style)
        {
        }

        protected PDFStyle(PDFObjectType type)
            : base(type)
        {
        }

        //
        // public methods
        //

        public void DataBind(PDFDataContext context)
        {
            this.OnDataBinding(context);
            this.DoDataBind(context, true);
            this.OnDataBound(context);
        }

        //
        // createXXX methods
        //

        #region public PDFPositionOptions CreatePostionOptions()

        /// <summary>
        /// Creates and returns the position options for this style.
        /// </summary>
        /// <returns></returns>
        public PDFPositionOptions CreatePostionOptions()
        {
           return this.DoCreatePositionOptions();
        }

        #endregion

        #region public PDFTextRenderOptions CreateTextOptions()

        /// <summary>
        /// Creates and returns the text options for this style
        /// </summary>
        /// <returns></returns>
        public PDFTextRenderOptions CreateTextOptions()
        {
            return this.DoCreateTextOptions();
        }

        #endregion

        #region public PDFColumnOptions CreateColumnOptions()

        /// <summary>
        /// Creates and returns the column options for this style
        /// </summary>
        /// <returns></returns>
        public PDFColumnOptions CreateColumnOptions()
        {
            return this.DoCreateColumnOptions();
        }

        #endregion

        #region public PDFPageSize CreatePageSize()

        /// <summary>
        /// Creates and returns the page size options for this style
        /// </summary>
        /// <returns></returns>
        public PDFPageSize CreatePageSize()
        {
            return this.DoCreatePageSize();
        }

        #endregion

        #region public PDFFont CreateFont()

        /// <summary>
        /// Creates and returns the font for this style.
        /// </summary>
        /// <returns></returns>
        public PDFFont CreateFont()
        {
            return this.DoCreateFont(true);
        }

        #endregion

        #region public PDFThickness CreatePaddingThickness()

        /// <summary>
        /// Returns the PDFThickness associated with the Padding for this style
        /// </summary>
        /// <returns></returns>
        public PDFThickness CreatePaddingThickness()
        {
            return this.DoCreatePaddingThickness();
        }

        #endregion

        #region public PDFThickness CreateMarginsThickness()

        /// <summary>
        /// Returns the PDFThickness associated with the Margins for this style
        /// </summary>
        /// <returns></returns>
        public PDFThickness CreateMarginsThickness()
        {
            return this.DoCreateMarginsThickness();
        }

        #endregion

        #region public PDFThickness CreateClippingThickness()

        /// <summary>
        /// the PDFThickness associated with the Clipping for this style
        /// </summary>
        /// <returns></returns>
        public PDFThickness CreateClippingThickness()
        {
            return this.DoCreateClippingThickness();
        }

        #endregion

        #region public PDFPageNumberOptions CreatePageNumberOptions()

        /// <summary>
        /// Gets the page numbering options for this style
        /// </summary>
        /// <returns></returns>
        public PDFPageNumberOptions CreatePageNumberOptions()
        {
            return this.DoCreatePageNumberOptions();
        }

        #endregion

        #region public PDFPen CreateBorderPen()

        /// <summary>
        /// Creates a new appropriate PDFPen if this style has any border attributes assigned, otherwise returns null
        /// </summary>
        /// <returns></returns>
        public PDFPen CreateBorderPen()
        {
            return this.DoCreateBorderPen();
        }

        #endregion

        #region public PDFBrush CreateBackgroundBrush()

        /// <summary>
        /// Creates a new appropriate PDFBrush 
        /// for this style if it has any background attributes set, otherwise returns null
        /// </summary>
        /// <returns></returns>
        public PDFBrush CreateBackgroundBrush()
        {
            return this.DoCreateBackgroundBrush();
        }

        #endregion

        #region public PDFBrush CreateFillBrush()

        /// <summary>
        /// Creates a new appropriate PDFBrush 
        /// for this style if it has any fill attributes set, otherwise returns null
        /// </summary>
        /// <returns></returns>
        public PDFBrush CreateFillBrush()
        {
            return this.DoCreateFillBrush();
        }

        #endregion

        #region public PDFPen CreateStrokePen()

        /// <summary>
        /// Creates a new appropriate PDFPen 
        /// for this style if it has any stroke attributes set, otherwise returns null
        /// </summary>
        /// <returns></returns>
        public PDFPen CreateStrokePen()
        {
            try
            {
                return this.DoCreateStrokePen();
            }
            catch (Exception ex)
            {
                throw new PDFException(string.Format(Errors.CouldNotCreateTheGraphicObjectFromTheStyle, "Stroke pen", ex.Message), ex);
            }
        }

        #endregion

        #region public PDFPen CreateOverlayGridPen()

        /// <summary>
        /// Creates a new appropriate PDFPen 
        /// for this style if it has any overlay grid attributes set, otherwise returns null
        /// </summary>
        /// <returns></returns>
        public PDFPen CreateOverlayGridPen()
        {
            return this.DoCreateOverlayGridPen();
        }

        #endregion


        //
        // Parsing
        //

        public static PDFStyle Parse(string value)
        {
            CSSStyleItemReader reader = new CSSStyleItemReader(value);
            PDFStyle style = new PDFStyle();

            while (reader.ReadNextAttributeName())
            {
                var parser = new CSSStyleItemAllParser();
                parser.SetStyleValue(style, reader);
            }
            return style;
        }
    }


}

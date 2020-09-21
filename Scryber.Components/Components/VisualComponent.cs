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

using System;
using System.Collections.Generic;
using System.Text;
using Scryber.Native;
using System.Drawing;
using Scryber.Styles;
using Scryber.Resources;
using Scryber.Drawing;

namespace Scryber.Components
{
    public abstract class VisualComponent : ContainerComponent, IPDFVisualComponent, IPDFStyledComponent, IPDFDataStyledComponent
    {


        #region public PDFStyle Style {get;set;} + public bool HasStyle{get;}

        private Style _style;

        /// <summary>
        /// Gets the applied style for this page Component
        /// </summary>
        [PDFElement("Style")]
        public virtual Style Style
        {
            get 
            {
                if (_style == null)
                {
                    _style = new Style();
                    _style.Priority = Style.DirectStylePriority;
                }
                return _style; 
            }
            set
            {
                this._style = value;
            }
        }

        

        /// <summary>
        /// Gets the flag to indicate if this page Component has style 
        /// information associated with it.
        /// </summary>
        public bool HasStyle
        {
            get { return this._style != null && this._style.HasValues; }
        }

        #endregion


        //
        // Style qualified accessor attributes
        //

        #region public PDFUnit X {get;set;} + public bool HasX {get;}

        /// <summary>
        /// Gets or Sets the X (Horizontal) position of this page Component
        /// </summary>
        [PDFAttribute("x", Const.PDFStylesNamespace)]
        [PDFDesignable("X", Ignore = true, Category ="Position",Priority = 1,Type ="PDFUnit")]
        [PDFJSConvertor("scryber.studio.design.convertors.unit_css", JSParams = "\"left\"")]
        public virtual PDFUnit X
        {
            get
            {
                StyleValue<PDFUnit> x;
                if (this.HasStyle && this.Style.TryGetValue(StyleKeys.PositionXKey, out x))
                    return x.Value;
                else
                    return PDFUnit.Empty;
            }
            set
            {
                this.Style.SetValue(StyleKeys.PositionXKey, value);
            }
        }

        /// <summary>
        /// Gets the flag to identify if the X position has been set for this Page Component
        /// </summary>
        public virtual bool HasX
        {
            get
            {
                StyleValue<PDFUnit> x;
                return this.HasStyle && this._style.TryGetValue(StyleKeys.PositionXKey, out x);
            }
        }

        #endregion

        #region public PDFUnit Y {get;set;} + public bool HasY {get;}

        /// <summary>
        /// Gets or sets the Y (vertical) position of the Page Component
        /// </summary>
        [PDFAttribute("y", Const.PDFStylesNamespace)]
        [PDFDesignable("Y", Ignore = true, Category = "Position", Priority = 1, Type = "PDFUnit")]
        [PDFJSConvertor("scryber.studio.design.convertors.unit_css", JSParams = "\"top\"")]
        public virtual PDFUnit Y
        {
            get
            {
                StyleValue<PDFUnit> y;
                if (this.HasStyle && this.Style.TryGetValue(StyleKeys.PositionYKey, out y))
                    return y.Value;
                else
                    return PDFUnit.Empty;
            }
            set
            {
                this.Style.SetValue(StyleKeys.PositionYKey, value);
            }
        }

        /// <summary>
        /// Gets the flag to identifiy is the Y value has been set on this page Component
        /// </summary>
        public virtual bool HasY
        {
            get
            {
                StyleValue<PDFUnit> x;
                return this.HasStyle && this._style.TryGetValue(StyleKeys.PositionYKey, out x);
            }
        }

        #endregion

        #region public PDFUnit Width {get;set;} + public bool HasWidth {get;}

        /// <summary>
        /// Gets or Sets the Width of this page Component
        /// </summary>
        [PDFAttribute("width", Const.PDFStylesNamespace)]
        [PDFDesignable("Width", Category = "Size", Priority = 1, Type = "PDFUnit")]
        [PDFJSConvertor("scryber.studio.design.convertors.unit_css", JSParams = "\"width\"")]
        public virtual PDFUnit Width
        {
            get
            {
                StyleValue<PDFUnit> width;
                if (this.HasStyle && this.Style.TryGetValue(StyleKeys.SizeWidthKey, out width))
                    return width.Value;
                else
                    return PDFUnit.Empty;
            }
            set
            {
                this.Style.SetValue(StyleKeys.SizeWidthKey, value);
            }
        }

        

        /// <summary>
        /// Gets the flag to identify if the Width has been set for this Page Component
        /// </summary>
        public virtual bool HasWidth
        {
            get
            {
                StyleValue<PDFUnit> width;
                return this.HasStyle && this._style.TryGetValue(StyleKeys.SizeWidthKey, out width);
            }
        }

        #endregion

        #region public PDFUnit Height {get;set;} + public bool HasHeight {get;}

        /// <summary>
        /// Gets or sets the Height of the Page Component
        /// </summary>
        [PDFAttribute("height", Const.PDFStylesNamespace)]
        [PDFDesignable("Height", Category = "Size", Priority = 1, Type = "PDFUnit")]
        [PDFJSConvertor("scryber.studio.design.convertors.unit_css", JSParams = "\"height\"")]
        public virtual PDFUnit Height
        {
            get
            {
                StyleValue<PDFUnit> height;
                if (this.HasStyle && this.Style.TryGetValue(StyleKeys.SizeHeightKey, out height))
                    return height.Value;
                else
                    return PDFUnit.Empty;
            }
            set
            {
                this.Style.SetValue(StyleKeys.SizeHeightKey, value);
            }
        }

        /// <summary>
        /// Gets the flag to identifiy is the Height has been set on this page Component
        /// </summary>
        public virtual bool HasHeight
        {
            get
            {
                StyleValue<PDFUnit> height;
                return this.HasStyle && this._style.TryGetValue(StyleKeys.SizeHeightKey, out height);
            }
        }

        #endregion


        #region public PDFUnit MinimumWidth {get;set;} + public bool HasMinimumWidth {get;}

        /// <summary>
        /// Gets or Sets the Width of this page Component
        /// </summary>
        [PDFAttribute("min-width", Const.PDFStylesNamespace)]
        [PDFJSConvertor("scryber.studio.design.convertors.unit_css", JSParams = "\"min-width\"")]
        [PDFDesignable("Min. Width", Ignore = true, Category = "Size", Priority = 10, Type = "PDFUnit")]
        public virtual PDFUnit MinimumWidth
        {
            get
            {
                StyleValue<PDFUnit> width;
                if (this.HasStyle && this.Style.TryGetValue(StyleKeys.SizeMinimumWidthKey, out width))
                    return width.Value;
                else
                    return PDFUnit.Empty;
            }
            set
            {
                this.Style.SetValue(StyleKeys.SizeMinimumWidthKey, value);
            }
        }



        /// <summary>
        /// Gets the flag to identify if the Width has been set for this Page Component
        /// </summary>
        public virtual bool HasMinimumWidth
        {
            get
            {
                StyleValue<PDFUnit> width;
                return this.HasStyle && this._style.TryGetValue(StyleKeys.SizeMinimumWidthKey, out width);
            }
        }

        #endregion

        #region public PDFUnit MinimumHeight {get;set;} + public bool HasMinimumHeight {get;}

        /// <summary>
        /// Gets or sets the Height of the Page Component
        /// </summary>
        [PDFAttribute("min-height", Const.PDFStylesNamespace)]
        [PDFJSConvertor("scryber.studio.design.convertors.unit_css", JSParams = "\"min-height\"")]
        [PDFDesignable("Min. Height", Ignore = true, Category = "Size", Priority = 10, Type = "PDFUnit")]
        public virtual PDFUnit MinimumHeight
        {
            get
            {
                StyleValue<PDFUnit> height;
                if (this.HasStyle && this.Style.TryGetValue(StyleKeys.SizeMinimumHeightKey, out height))
                    return height.Value;
                else
                    return PDFUnit.Empty;
            }
            set
            {
                this.Style.SetValue(StyleKeys.SizeMinimumHeightKey, value);
            }
        }

        /// <summary>
        /// Gets the flag to identifiy is the Height has been set on this page Component
        /// </summary>
        public virtual bool HasMinimumHeight
        {
            get
            {
                StyleValue<PDFUnit> height;
                return this.HasStyle && this._style.TryGetValue(StyleKeys.SizeMinimumHeightKey, out height);
            }
        }

        #endregion


        #region public PDFUnit MaximumWidth {get;set;} + public bool HasMaximumWidth {get;}

        /// <summary>
        /// Gets or Sets the Width of this page Component
        /// </summary>
        [PDFAttribute("max-width", Const.PDFStylesNamespace)]
        [PDFJSConvertor("scryber.studio.design.convertors.unit_css", JSParams = "\"max-width\"")]
        [PDFDesignable("Max Width", Ignore = true, Category = "Size", Priority = 10, Type = "PDFUnit")]
        public virtual PDFUnit MaximumWidth
        {
            get
            {
                StyleValue<PDFUnit> width;
                if (this.HasStyle && this.Style.TryGetValue(StyleKeys.SizeMaximumWidthKey, out width))
                    return width.Value;
                else
                    return PDFUnit.Empty;
            }
            set
            {
                this.Style.SetValue(StyleKeys.SizeMaximumWidthKey, value);
            }
        }



        /// <summary>
        /// Gets the flag to identify if the Width has been set for this Page Component
        /// </summary>
        public virtual bool HasMaximumWidth
        {
            get
            {
                StyleValue<PDFUnit> width;
                return this.HasStyle && this._style.TryGetValue(StyleKeys.SizeMaximumWidthKey, out width);
            }
        }

        #endregion

        #region public PDFUnit MaximumHeight {get;set;} + public bool HasMaximumHeight {get;}

        /// <summary>
        /// Gets or sets the Height of the Page Component
        /// </summary>
        [PDFAttribute("max-height", Const.PDFStylesNamespace)]
        [PDFJSConvertor("scryber.studio.design.convertors.unit_css", JSParams = "\"max-height\"")]
        [PDFDesignable("Max Height", Ignore = true, Category = "Size", Priority = 10, Type = "PDFUnit")]
        public virtual PDFUnit MaximumHeight
        {
            get
            {
                StyleValue<PDFUnit> height;
                if (this.HasStyle && this.Style.TryGetValue(StyleKeys.SizeMaximumHeightKey, out height))
                    return height.Value;
                else
                    return PDFUnit.Empty;
            }
            set
            {
                this.Style.SetValue(StyleKeys.SizeMaximumHeightKey, value);
            }
        }

        /// <summary>
        /// Gets the flag to identifiy is the Height has been set on this page Component
        /// </summary>
        public virtual bool HasMaximumHeight
        {
            get
            {
                StyleValue<PDFUnit> height;
                return this.HasStyle && this._style.TryGetValue(StyleKeys.SizeMaximumHeightKey, out height);
            }
        }

        #endregion

        

        #region public PDFThickness Margins

        /// <summary>
        /// Gets or sets the margins for this component
        /// </summary>
        [PDFAttribute("margins",Const.PDFStylesNamespace)]
        [PDFJSConvertor("scryber.studio.design.convertors.thickness_css", JSParams = "\"margin\"")]
        [PDFDesignable("Margins", Category = "Layout", Priority = 2, Type = "PDFThickness")]
        public PDFThickness Margins
        {
            get
            {
                if (this.HasStyle)
                    return this.Style.CreateMarginsThickness();
                else
                    return PDFThickness.Empty();
            }
            set
            {
                this.Style.SetMargins(value);
            }
        }

        #endregion

        #region public PDFThickness Padding

        /// <summary>
        /// Gets or sets the padding on this component
        /// </summary>
        [PDFAttribute("padding",Const.PDFStylesNamespace)]
        [PDFJSConvertor("scryber.studio.design.convertors.thickness_css", JSParams = "\"padding\"")]
        [PDFDesignable("Padding", Category = "Layout", Priority = 2, Type = "PDFThickness")]
        public PDFThickness Padding
        {
            get
            {
                if (this.HasStyle)
                    return this.Style.CreatePaddingThickness();
                else
                    return PDFThickness.Empty();
            }
            set
            {
                this.Style.SetPadding(value);
            }
        }

        #endregion


        #region public PDFColor BackgroundColor

        /// <summary>
        /// Gets or sets the background color of this component
        /// </summary>
        [PDFAttribute("bg-color",Const.PDFStylesNamespace)]
        [PDFJSConvertor("scryber.studio.design.convertors.color_css", JSParams = "\"background-color\"")]
        [PDFDesignable("Color", Category = "Background", Priority = 1, Type = "Color")]
        public PDFColor BackgroundColor
        {
            get
            {
                StyleValue<PDFColor> color;
                if (this.HasStyle && this.Style.TryGetValue(StyleKeys.BgColorKey, out color))
                    return color.Value;
                else
                    return PDFColors.Transparent;
            }
            set
            {
                this.Style.SetValue(StyleKeys.BgColorKey, value);
            }
        }

        #endregion

        #region public string BackgroundImage

        /// <summary>
        /// Gets or sets the background image of this component
        /// </summary>
        [PDFAttribute("bg-image", Const.PDFStylesNamespace)]
        [PDFDesignable("Image", Category = "Background", Priority = 2, Type = "ImageSource")]
        [PDFJSConvertor("scryber.studio.design.convertors.imgSource_attr")]
        public string BackgroundImage
        {
            get
            {
                StyleValue<string> img;
                if (this.HasStyle && this.Style.TryGetValue(StyleKeys.BgImgSrcKey, out img))
                    return img.Value;
                else
                    return string.Empty;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    this.Style.RemoveValue(StyleKeys.BgImgSrcKey);
                else
                    this.Style.SetValue(StyleKeys.BgImgSrcKey, value);
            }
        }

        #endregion

        #region public PatternRepeat BackgroundRepeat

        /// <summary>
        /// Gets or sets the background image repeat of this component
        /// </summary>
        [PDFAttribute("bg-repeat", Const.PDFStylesNamespace)]
        [PDFDesignable("Repeat", Category = "Background", Priority = 2, Type = "Select")]
        [PDFJSConvertor("scryber.studio.design.convertors.bgRepeat_attr")]
        public PatternRepeat BackgroundRepeat
        {
            get
            {
                StyleValue<PatternRepeat> repeat;
                if (this.HasStyle && this.Style.TryGetValue(StyleKeys.BgRepeatKey, out repeat))
                    return repeat.Value;
                else
                    return PatternRepeat.RepeatBoth;
            }
            set
            {
                this.Style.SetValue(StyleKeys.BgRepeatKey, value);
            }
        }

        #endregion

        #region public PDFReal BackgroundOpacity

        /// <summary>
        /// Gets or sets the background fill color opacity of this component
        /// </summary>
        [PDFAttribute("bg-opacity", Const.PDFStylesNamespace)]
        [PDFDesignable("Opacity", Ignore = true, Category = "Background", Priority = 3, Type = "Percent")]
        [PDFJSConvertor("scryber.studio.design.convertors.opacity_css", JSParams = "\"bg-opacity\"")]
        public PDFReal BackgroundOpacity
        {
            get
            {
                StyleValue<double> op;
                if (this.HasStyle && this.Style.TryGetValue(StyleKeys.BgOpacityKey, out op))
                    return (PDFReal)op.Value;
                else
                    return PDFReal.Zero;
            }
            set
            {
                this.Style.SetValue(StyleKeys.BgOpacityKey, value.Value);
            }
        }

        #endregion



        #region public PDFUnit BorderWidth

        /// <summary>
        /// Gets or sets the border width of this component
        /// </summary>
        [PDFAttribute("border-width", Const.PDFStylesNamespace)]
        [PDFDesignable("Width", Category = "Border", Priority = 1, Type = "PDFUnit")]
        [PDFJSConvertor("scryber.studio.design.convertors.borderwidth_css", JSParams = "\"border-width\"")]
        public PDFUnit BorderWidth
        {
            get
            {
                StyleValue<PDFUnit> w;
                if (this.HasStyle && this.Style.TryGetValue(StyleKeys.BorderWidthKey, out w))
                    return w.Value;
                else
                    return PDFUnit.Empty;
            }
            set
            {
                this.Style.SetValue(StyleKeys.BorderWidthKey, value);
            }
        }

        #endregion

        #region public PDFColor BorderColor

        /// <summary>
        /// Gets or sets the border color of this component
        /// </summary>
        [PDFAttribute("border-color", Const.PDFStylesNamespace)]
        [PDFDesignable("Color", Category = "Border", Priority = 1, Type = "Color")]
        [PDFJSConvertor("scryber.studio.design.convertors.color_css", JSParams = "\"border-color\"")]
        public PDFColor BorderColor
        {
            get
            {
                StyleValue<PDFColor> val;
                if (this.HasStyle && this.Style.TryGetValue(StyleKeys.BorderColorKey, out val))
                    return val.Value;
                else
                    return PDFColors.Transparent;
            }
            set
            {
                this.Style.SetValue(StyleKeys.BorderColorKey, value);
            }
        }

        #endregion

        #region public PDFDash BorderDashPattern

        /// <summary>
        /// Gets or sets the border dash pattern of this component
        /// </summary>
        [PDFAttribute("border-dash", Const.PDFStylesNamespace)]
        [PDFDesignable("Dash", Category = "Border", Priority = 3, Type = "Select")]
        public PDFDash BorderDashPattern
        {
            get
            {
                StyleValue<PDFDash> val;
                if (this.HasStyle && this.Style.TryGetValue(StyleKeys.BorderDashKey, out val))
                    return val.Value;
                else
                    return PDFDash.None;
            }
            set
            {
                if (null == value)
                    this.Style.RemoveValue(StyleKeys.BorderDashKey);
                else
                    this.Style.SetValue(StyleKeys.BorderDashKey, value);
            }
        }

        #endregion

        #region public double BorderOpacity

        /// <summary>
        /// Gets or sets the border opacity of this component
        /// </summary>
        [PDFAttribute("border-opacity", Const.PDFStylesNamespace)]
        [PDFDesignable("Opacity", Ignore = true, Category = "Border", Priority = 2, Type = "Percent")]
        public double BorderOpacity
        {
            get
            {
                StyleValue<double> val;
                if (this.HasStyle && this.Style.TryGetValue(StyleKeys.BorderOpacityKey, out val))
                    return val.Value;
                else
                    return 1;
            }
            set
            {
                this.Style.SetValue(StyleKeys.BorderOpacityKey, value);
            }
        }

        #endregion

        #region public Sides BorderSides

        /// <summary>
        /// Gets or sets the border sides of this component
        /// </summary>
        [PDFAttribute("border-sides", Const.PDFStylesNamespace)]
        [PDFJSConvertor("scryber.studio.design.convertors.bordersides_css", JSParams = "\"border\"")]
        [PDFDesignable("Sides", Ignore = false, Category = "Border", Priority = 3, Type = "FlagsSelect")]
        public Sides BorderSides
        {
            get
            {
                StyleValue<Sides> val;
                if (this.HasStyle && this.Style.TryGetValue(StyleKeys.BorderSidesKey, out val))
                    return val.Value;
                else
                    return (Sides.Bottom | Sides.Left | Sides.Right | Sides.Top);
            }
            set
            {
                this.Style.SetValue(StyleKeys.BorderSidesKey, value);
            }
        }

        #endregion

        #region public PDFUnit BorderCornerRadius

        /// <summary>
        /// Gets or sets the border corner radii of this component
        /// </summary>
        [PDFAttribute("border-corner-radius", Const.PDFStylesNamespace)]
        [PDFDesignable("Corner Radius", Category = "Border", Priority = 2, Type = "PDFUnit")]
        [PDFJSConvertor("scryber.studio.design.convertors.unit_css", JSParams = "\"border-radius\"")]
        public PDFUnit BorderCornerRadius
        {
            get
            {
                StyleValue<PDFUnit> val;
                if (this.HasStyle && this.Style.TryGetValue(StyleKeys.BorderCornerRadiusKey, out val))
                    return val.Value;
                else
                    return PDFUnit.Zero;
            }
            set
            {
                this.Style.SetValue(StyleKeys.BorderCornerRadiusKey, value);
            }
        }

        #endregion

        #region public LineStyle BorderStyle

        [PDFAttribute("border-style", Const.PDFStylesNamespace)]
        [PDFDesignable("Style", Category = "Border", Priority = 2, Type = "Select")]
        [PDFJSConvertor("scryber.studio.design.convertors.borderstyle_css")]
        public LineType BorderStyle
        {
            get
            {
                StyleValue<LineType> val;
                if (this.HasStyle && this.Style.TryGetValue(StyleKeys.BorderStyleKey, out val))
                    return val.Value;
                else
                    return LineType.None;
            }
            set
            {
                this.Style.SetValue(StyleKeys.BorderStyleKey, value);
            }
        }

        #endregion

        #region public PDFColor FillColor

        /// <summary>
        /// Gets or sets the Fill color of this component
        /// </summary>
        [PDFAttribute("fill-color", Const.PDFStylesNamespace)]
        [PDFJSConvertor("scryber.studio.design.convertors.color_css", JSParams = "\"color\"")]
        [PDFDesignable("Color", Category = "Fill", Priority = 1, Type = "PDFColor")]
        public PDFColor FillColor
        {
            get
            {
                StyleValue<PDFColor> val;
                if (this.HasStyle && this.Style.TryGetValue(StyleKeys.FillColorKey, out val))
                    return val.Value;
                else
                    return PDFColors.Transparent;
            }
            set
            {
                this.Style.SetValue(StyleKeys.FillColorKey, value);
            }
        }

        #endregion

        #region public string FillImage

        /// <summary>
        /// Gets or sets the Fill image of this component
        /// </summary>
        [PDFAttribute("fill-image", Const.PDFStylesNamespace)]
        [PDFDesignable("Image", Ignore = true, Category = "Fill", Priority = 2, Type = "ImageFile")]
        public string FillImage
        {
            get
            {
                StyleValue<string> val;
                if (this.HasStyle && this.Style.TryGetValue(StyleKeys.FillImgSrcKey, out val))
                    return val.Value;
                else
                    return string.Empty;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    this.Style.RemoveValue(StyleKeys.FillImgSrcKey);
                else
                    this.Style.SetValue(StyleKeys.FillImgSrcKey, value);
            }
        }

        #endregion

        #region public PatternRepeat FillRepeat

        /// <summary>
        /// Gets or sets the Fill image repeat of this component
        /// </summary>
        [PDFAttribute("fill-repeat", Const.PDFStylesNamespace)]
        [PDFDesignable("Repeat", Ignore = true,  Category = "Fill", Priority = 2, Type = "Select")]
        public PatternRepeat FillRepeat
        {
            get
            {
                StyleValue<PatternRepeat> val;
                if (this.HasStyle && this.Style.TryGetValue(StyleKeys.FillRepeatKey, out val))
                    return val.Value;
                else
                    return PatternRepeat.RepeatBoth;
            }
            set
            {
                this.Style.SetValue(StyleKeys.FillRepeatKey, value);
            }
        }

        #endregion

        #region public PDFReal FillOpacity

        /// <summary>
        /// Gets or sets the Fill color opacity of this component
        /// </summary>
        [PDFAttribute("fill-opacity", Const.PDFStylesNamespace)]
        [PDFDesignable("Opacity", Category = "Fill", Priority = 1, Type = "Percent")]
        [PDFJSConvertor("scryber.studio.design.convertors.opacity_css", JSParams = "\"opacity\"")]
        public PDFReal FillOpacity
        {
            get
            {
                StyleValue<double> val;
                if (this.HasStyle && this.Style.TryGetValue(StyleKeys.FillOpacityKey, out val))
                    return val.Value;
                else
                    return PDFReal.Zero;
            }
            set
            {
                this.Style.SetValue(StyleKeys.FillOpacityKey, value.Value);
            }
        }

        #endregion



        #region public PDFUnit StrokeWidth

        /// <summary>
        /// Gets or sets the Stroke width of this component
        /// </summary>
        [PDFAttribute("stroke-width", Const.PDFStylesNamespace)]
        [PDFJSConvertor("scryber.studio.design.convertors.unit_css", JSParams = "\"stroke-width\"")]
        [PDFDesignable("Width", Category = "Stroke", Priority = 1, Type = "PDFUnit")]
        public PDFUnit StrokeWidth
        {
            get
            {
                StyleValue<PDFUnit> val;
                if (this.HasStyle && this.Style.TryGetValue(StyleKeys.StrokeWidthKey, out val))
                    return val.Value;
                else
                    return PDFUnit.Empty;
            }
            set
            {
                this.Style.SetValue(StyleKeys.StrokeWidthKey, value);
            }
        }

        #endregion

        #region public PDFColor StrokeColor

        /// <summary>
        /// Gets or sets the Stroke color of this component
        /// </summary>
        [PDFAttribute("stroke-color", Const.PDFStylesNamespace)]
        [PDFJSConvertor("scryber.studio.design.convertors.color_css", JSParams = "\"stroke\"")]
        [PDFDesignable("Color", Category = "Stroke", Priority = 1, Type = "Color")]
        public PDFColor StrokeColor
        {
            get
            {
                StyleValue<PDFColor> val;
                if (this.HasStyle && this.Style.TryGetValue(StyleKeys.StrokeColorKey, out val))
                    return val.Value;
                else
                    return PDFColors.Transparent;
            }
            set
            {
                if (null == value)
                    this.Style.RemoveValue(StyleKeys.StrokeColorKey);
                else
                    this.Style.SetValue(StyleKeys.StrokeColorKey, value);
            }
        }

        #endregion

        #region public PDFDash StrokeDashPattern

        /// <summary>
        /// Gets or sets the Stroke dash pattern of this component
        /// </summary>
        [PDFAttribute("stroke-dash", Const.PDFStylesNamespace)]
        [PDFDesignable("Dash", Category = "Stroke", Priority = 3, Type = "Select")]
        public PDFDash StrokeDashPattern
        {
            get
            {
                StyleValue<PDFDash> val;
                if (this.HasStyle && this.Style.TryGetValue(StyleKeys.StrokeDashKey, out val))
                    return val.Value;
                else
                    return PDFDash.None;
            }
            set
            {
                if (null == value)
                    this.Style.RemoveValue(StyleKeys.StrokeDashKey);
                else
                    this.Style.SetValue(StyleKeys.StrokeDashKey, value);
            }
        }

        #endregion

        #region public double StrokeOpacity

        /// <summary>
        /// Gets or sets the Stroke opacity of this component
        /// </summary>
        [PDFAttribute("stroke-opacity", Const.PDFStylesNamespace)]
        [PDFDesignable("Opacity", Category = "Stroke", Priority = 2, Type = "Percent")]
        public double StrokeOpacity
        {
            get
            {
                StyleValue<double> val;
                if (this.HasStyle && this.Style.TryGetValue(StyleKeys.StrokeOpacityKey, out val))
                    return val.Value;
                else
                    return 1;
            }
            set
            {
                this.Style.Stroke.Opacity = value;
            }
        }

        #endregion



        #region public string FontFamily

        /// <summary>
        /// Gets or sets the Font Family of this component
        /// </summary>
        [PDFAttribute("font-family", Const.PDFStylesNamespace)]
        [PDFDesignable("Family", Category = "Font", Priority = 1, Type = "Select")]
        [PDFJSConvertor("scryber.studio.design.convertors.string_css", JSParams = "\"font-family\"")]
        public string FontFamily
        {
            get
            {
                StyleValue<string> val;
                if (this.HasStyle && this.Style.TryGetValue(StyleKeys.FontFamilyKey, out val))
                    return val.Value;
                else
                    return string.Empty;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    this.Style.RemoveValue(StyleKeys.FontFamilyKey);
                else
                    this.Style.SetValue(StyleKeys.FontFamilyKey,value);
            }
        }

        #endregion

        #region public string FontSize

        /// <summary>
        /// Gets or sets the Font Size of this component
        /// </summary>
        [PDFAttribute("font-size", Const.PDFStylesNamespace)]
        [PDFJSConvertor("scryber.studio.design.convertors.unit_css", JSParams ="\"font-size\"")]
        [PDFDesignable("Size", Category = "Font", Priority = 1, Type = "PDFUnit")]
        public PDFUnit FontSize
        {
            get
            {
                StyleValue<PDFUnit> val;
                if (this.HasStyle && this.Style.TryGetValue(StyleKeys.FontSizeKey, out val))
                    return val.Value;
                else
                    return PDFUnit.Zero;
            }
            set
            {
                this.Style.SetValue(StyleKeys.FontSizeKey, value);
            }
        }

        #endregion

        #region public bool FontBold

        /// <summary>
        /// Gets or sets the Font bold value of this component
        /// </summary>
        [PDFAttribute("font-bold", Const.PDFStylesNamespace)]
        [PDFJSConvertor("scryber.studio.design.convertors.bold_css", JSParams = "\"font-weight\"")]
        [PDFDesignable("Bold", Category = "Font", Priority = 2, Type = "Boolean")]
        public bool FontBold
        {
            get
            {
                StyleValue<bool> val;
                if (this.HasStyle && this.Style.TryGetValue(StyleKeys.FontBoldKey, out val))
                    return val.Value;
                else
                    return false;
            }
            set
            {
                this.Style.SetValue(StyleKeys.FontBoldKey, value);
            }
        }

        #endregion

        #region public bool FontItalic

        /// <summary>
        /// Gets or sets the Font italic value of this component
        /// </summary>
        [PDFAttribute("font-italic", Const.PDFStylesNamespace)]
        [PDFJSConvertor("scryber.studio.design.convertors.italic_css", JSParams = "\"font-style\"")]
        [PDFDesignable("Italic", Category = "Font", Priority = 2, Type = "Boolean")]
        public bool FontItalic
        {
            get
            {
                StyleValue<bool> val;
                if (this.HasStyle && this.Style.TryGetValue(StyleKeys.FontItalicKey, out val))
                    return val.Value;
                else
                    return false;
            }
            set
            {
                this.Style.SetValue(StyleKeys.FontItalicKey, value);
            }
        }

        #endregion


        #region public HorizontalAlignment HorizontalAlignment

        /// <summary>
        /// Gets or sets the Horizontal alignment of this component
        /// </summary>
        [PDFAttribute("h-align", Const.PDFStylesNamespace)]
        [PDFJSConvertor("scryber.studio.design.convertors.halign_css")]
        [PDFDesignable("H. Align", Category = "Layout", Priority = 1, Type = "Select")]
        public HorizontalAlignment HorizontalAlignment
        {
            get
            {
                StyleValue<HorizontalAlignment> val;
                if (this.HasStyle && this.Style.TryGetValue(StyleKeys.PositionHAlignKey, out val))
                    return val.Value;
                else
                    return HorizontalAlignment.Left;
            }
            set
            {
                this.Style.SetValue(StyleKeys.PositionHAlignKey, value);
            }
        }

        #endregion

        #region public VerticalAlignment VerticalAlignment

        /// <summary>
        /// Gets or sets the vertical alignment of this component
        /// </summary>
        [PDFAttribute("v-align", Const.PDFStylesNamespace)]
        [PDFJSConvertor("scryber.studio.design.convertors.valign_css")]
        [PDFDesignable("V. Align", Category = "Layout", Priority = 1, Type = "Select")]
        public VerticalAlignment VerticalAlignment
        {
            get
            {
                StyleValue<VerticalAlignment> val;
                if (this.HasStyle && this.Style.TryGetValue(StyleKeys.PositionVAlignKey, out val))
                    return val.Value;
                else
                    return VerticalAlignment.Top;
            }
            set
            {
                this.Style.SetValue(StyleKeys.PositionVAlignKey, value);
            }
        }

        #endregion

        #region public PositionMode PositionMode

        /// <summary>
        /// Gets or sets the position mode of this component (flow, relative, absolute)
        /// </summary>
        [PDFAttribute("position-mode", Const.PDFStylesNamespace)]
        [PDFDesignable("Position", Category = "Layout", Priority = 1, Type = "PositionMode")]
        [PDFJSConvertor("scryber.studio.design.convertors.positionMode_css")]
        public PositionMode PositionMode
        {
            get
            {
                StyleValue<PositionMode> val;
                if (this.HasStyle && this.Style.TryGetValue(StyleKeys.PositionModeKey, out val))
                    return val.Value;
                else
                    return PositionMode.Block;
            }
            set
            {
                this.Style.SetValue(StyleKeys.PositionModeKey, value);
            }
        }

        #endregion

        #region public bool FillWidth

        /// <summary>
        /// Gets or sets the fill-width style attribute
        /// </summary>
        [PDFAttribute("full-width",Const.PDFStylesNamespace)]
        [PDFJSConvertor("scryber.studio.design.convertors.fullwidth_css")]
        [PDFDesignable("Full Width", Category = "Size", Priority = 1, Type = "Boolean")]
        public bool FullWidth
        {
            get
            {
                StyleValue<bool> val;
                if (this.HasStyle && this.Style.TryGetValue(StyleKeys.SizeFullWidthKey, out val))
                    return val.Value;
                else
                    return false;
            }
            set
            {
                this.Style.SetValue(StyleKeys.SizeFullWidthKey, value);
            }
        }

        #endregion

        #region public int ColumnCount {get;set;}

        /// <summary>
        /// Gets or sets the column count in this visual component
        /// </summary>
        [PDFAttribute("column-count",Const.PDFStylesNamespace)]
        [PDFJSConvertor("scryber.studio.design.convertors.integer_attr", JSParams ="\"colspan\"")]
        [PDFDesignable("Column Count", Ignore = true)]
        public int ColumnCount
        {
            get
            {
                StyleValue<int> val;
                if (this.HasStyle && this.Style.TryGetValue(StyleKeys.ColumnCountKey, out val))
                    return val.Value;
                else
                    return 1;
            }
            set { this.Style.SetValue(StyleKeys.ColumnCountKey, value); }
        }

        #endregion

        #region public PDFUnit AlleyWidth {get;set;}

        /// <summary>
        /// Gets or sets the column count in this visual component
        /// </summary>
        [PDFAttribute("alley-width", Const.PDFStylesNamespace)]
        [PDFDesignable("Alley",Ignore = true)]
        public PDFUnit AlleyWidth
        {
            get
            {
                StyleValue<PDFUnit> val;
                if (this.HasStyle && this.Style.TryGetValue(StyleKeys.ColumnAlleyKey, out val))
                    return val.Value;
                else
                    return ColumnsStyle.DefaultAlleyWidth;
            }
            set { this.Style.SetValue(StyleKeys.ColumnAlleyKey, value); }
        }

        #endregion

        #region public PDFColumnWidths ColumnWidths {get;set;}

        /// <summary>
        /// Gets or sets the column widths in this visual component
        /// </summary>
        [PDFAttribute("column-widths", Const.PDFStylesNamespace)]
        [PDFDesignable("Column Widths", Ignore = true)]
        public PDFColumnWidths ColumnWidths
        {
            get
            {
                StyleValue<PDFColumnWidths> val;
                if (this.HasStyle && this.Style.TryGetValue(StyleKeys.ColumnWidthKey, out val))
                    return val.Value;
                else
                    return PDFColumnWidths.Empty;
            }
            set { this.Style.SetValue(StyleKeys.ColumnWidthKey, value); }
        }

        #endregion

        #region public WordWrap TextWrapping

        /// <summary>
        /// Gets or sets the text wrapping mode of this component
        /// </summary>
        [PDFAttribute("text-wrap", Const.PDFStylesNamespace)]
        [PDFDesignable("Wrapping", Category = "Text", Priority = 1, Type = "Select")]
        public Scryber.Text.WordWrap TextWrapping
        {
            get
            {
                StyleValue<Scryber.Text.WordWrap> val;
                if (this.HasStyle && this.Style.TryGetValue(StyleKeys.TextWordWrapKey, out val))
                    return val.Value;
                else
                    return Text.WordWrap.Auto;
            }
            set
            {
                this.Style.SetValue(StyleKeys.TextWordWrapKey, value);
            }
        }

        #endregion

        #region public PDFUnit TextLeading {get;set;}

        /// <summary>
        /// Gets or sets the leadiong on the characters (spacing between lines)
        /// </summary>
        [PDFAttribute("text-leading",Const.PDFStylesNamespace)]
        [PDFDesignable("Leading", Category = "Text", Priority = 1, Type = "PDFUnit")]
        public PDFUnit TextLeading
        {
            get
            {
                StyleValue<PDFUnit> val;
                if (this.HasStyle && this.Style.TryGetValue(StyleKeys.TextLeadingKey, out val))
                    return val.Value;
                else
                    return PDFUnit.Zero;
            }
            set
            {
                this.Style.SetValue(StyleKeys.TextLeadingKey, value);
            }
        }

        #endregion

        #region public Scryber.Text.TextDecoration TextDecoration {get;set;}

        /// <summary>
        /// Gets or sets the text decoration on the characters in this component
        /// </summary>
        [PDFAttribute("text-decoration", Const.PDFStylesNamespace)]
        [PDFDesignable("Decoration", Category = "Text", Priority = 1, Type = "MultiSelect")]
        public Scryber.Text.TextDecoration TextDecoration
        {
            get
            {
                StyleValue<Scryber.Text.TextDecoration> val;
                if (this.HasStyle && this.Style.TryGetValue(StyleKeys.TextDecorationKey, out val))
                    return val.Value;
                else
                    return Scryber.Text.TextDecoration.None;

            }
            set
            {
                this.Style.SetValue(StyleKeys.TextDecorationKey, value);
            }
        }

        #endregion

        #region public PDFUnit TextCharacterSpacing {get;set;}

        /// <summary>
        /// Gets or sets the extra character spacing in a chuck of text
        /// </summary>
        [PDFAttribute("text-char-spacing", Const.PDFStylesNamespace)]
        [PDFDesignable("Char Spacing", Category = "Text", Priority = 1, Type = "PDFUnit")]
        public PDFUnit TextCharacterSpacing
        {
            get
            {
                StyleValue<PDFUnit> val;
                if (this.HasStyle && this.Style.TryGetValue(StyleKeys.TextCharSpacingKey, out val))
                    return val.Value;
                else
                    return PDFUnit.Zero;

            }
            set
            {
                this.Style.SetValue(StyleKeys.TextCharSpacingKey, value);
            }
        }

        #endregion

        #region public PDFUnit TextWordSpacing {get;set;}

        /// <summary>
        /// Gets or sets the extra word spacing in a chuck of text - overrides char spacing on the ' ' character if set
        /// </summary>
        [PDFAttribute("text-word-spacing", Const.PDFStylesNamespace)]
        [PDFDesignable("Word Spacing", Category = "Text", Priority = 1, Type = "PDFUnit")]
        public PDFUnit TextWordSpacing
        {
            get
            {
                StyleValue<PDFUnit> val;
                if (this.HasStyle && this.Style.TryGetValue(StyleKeys.TextWordSpacingKey, out val))
                    return val.Value;
                else
                    return PDFUnit.Zero;

            }
            set
            {
                this.Style.SetValue(StyleKeys.TextWordSpacingKey, value);
            }
        }

        #endregion

        #region public double TextHorizontalScale {get;set;}

        /// <summary>
        /// Gets or sets the strech (or shrink) of characters in a chunk
        /// </summary>
        [PDFAttribute("text-h-scale", Const.PDFStylesNamespace)]
        [PDFDesignable("H Scale", Ignore =true, Category = "Text", Priority = 1, Type = "PercentPlus")]
        public double TextHorizontalScale
        {
            get
            {
                StyleValue<double> val;
                if (this.HasStyle && this.Style.TryGetValue(StyleKeys.TextHorizontalScaling, out val))
                    return val.Value;
                else
                    return 1.0;

            }
            set
            {
                this.Style.SetValue(StyleKeys.TextHorizontalScaling, value);
            }
        }

        #endregion

        #region public PDFUnit TextFirstLineIndent {get;set;}

        /// <summary>
        /// Gets or sets the extra space at the front of the first line of text in a block or after a hard return
        /// </summary>
        [PDFAttribute("text-first-indent", Const.PDFStylesNamespace)]
        [PDFDesignable("Indent", Ignore = true, Category = "Text", Priority = 1, Type = "PDFUnit")]
        public PDFUnit TextFirstLineIndent
        {
            get
            {
                StyleValue<PDFUnit> val;
                if (this.HasStyle && this.Style.TryGetValue(StyleKeys.TextFirstLineIndentKey, out val))
                    return val.Value;
                else
                    return PDFUnit.Zero;

            }
            set
            {
                this.Style.SetValue(StyleKeys.TextFirstLineIndentKey, value);
            }
        }

        #endregion

        #region public TextDirection TextDirection {get;set;}

        [PDFAttribute("text-direction", Const.PDFStylesNamespace)]
        [PDFDesignable("Text Direction", Ignore = true)]
        public TextDirection TextDirection
        {
            get
            {
                StyleValue<TextDirection> dir;
                if (this.HasStyle && this.Style.TryGetValue(StyleKeys.TextDirectionKey, out dir))
                    return dir.Value;
                else
                    return Scryber.TextDirection.LTR;
            }
            set
            {
                this.Style.SetValue(StyleKeys.TextDirectionKey, value);
            }
        }

        #endregion

        #region public OverflowSplit OverflowSplit {get; set;}

        /// <summary>
        /// Gets or sets the split option for this visual component
        /// </summary>
        [PDFAttribute("overflow-split",Const.PDFStylesNamespace)]
        [PDFDesignable("Overflow Split", Category = "Layout", Priority = 4, Type = "Select")]
        public OverflowSplit OverflowSplit
        {
            get
            {
                StyleValue<OverflowSplit> val;
                if (this.HasStyle && this.Style.TryGetValue(StyleKeys.OverflowSplitKey, out val))
                    return val.Value;
                else
                    return Drawing.OverflowSplit.Any;
            }
            set
            {
                this.Style.SetValue(StyleKeys.OverflowSplitKey, value);
            }
        }

        #endregion

        #region public string OutlineTitle {get;set;}

        /// <summary>
        /// Gets or sets the title of the outline for this component.
        /// </summary>
        [PDFAttribute("outline-title")]
        [PDFDesignable("Outline Title", Ignore = true, Category = "General", Priority = 4, Type = "String")]
        public virtual string OutlineTitle
        {
            get
            {
                if (this.HasOutline)
                    return this.Outline.Title;
                else
                    return string.Empty;
            }
            set
            {
                if (!this.HasOutline && string.IsNullOrEmpty(value))
                {
                    //Nothing to do as we don't have an outline and the value is empty
                    return;
                }
                this.Outline.Title = value;
            }
        }

        #endregion


        #region public bool PageBreakBefore {get; set;}

        /// <summary>
        /// Gets or sets the split option for this visual component
        /// </summary>
        [PDFAttribute("page-break-before", Const.PDFStylesNamespace)]
        [PDFDesignable("Page Break Before", Category = "Layout", Priority = 4, Type = "Boolean")]
        public bool PageBreakBefore
        {
            get
            {
                StyleValue<bool> val;
                if (this.HasStyle && this.Style.TryGetValue(StyleKeys.PageBreakBeforeKey, out val))
                    return val.Value;
                else
                    return false;
            }
            set
            {
                this.Style.SetValue(StyleKeys.PageBreakBeforeKey, value);
            }
        }

        #endregion

        #region public bool PageBreakAfter {get; set;}

        /// <summary>
        /// Gets or sets the split option for this visual component
        /// </summary>
        [PDFAttribute("page-break-after", Const.PDFStylesNamespace)]
        [PDFDesignable("Page Break Before", Category = "Layout", Priority = 4, Type = "Boolean")]
        public bool PageBreakAfter
        {
            get
            {
                StyleValue<bool> val;
                if (this.HasStyle && this.Style.TryGetValue(StyleKeys.PageBreakAfterKey, out val))
                    return val.Value;
                else
                    return false;
            }
            set
            {
                this.Style.SetValue(StyleKeys.PageBreakAfterKey, value);
            }
        }

        #endregion

        #region public bool ColumnBreakBefore {get; set;}

        /// <summary>
        /// Gets or sets the split option for this visual component
        /// </summary>
        [PDFAttribute("column-break-before", Const.PDFStylesNamespace)]
        [PDFDesignable("Column Break Before", Category = "Layout", Priority = 4, Type = "Boolean")]
        public bool ColumnBreakBefore
        {
            get
            {
                StyleValue<bool> val;
                if (this.HasStyle && this.Style.TryGetValue(StyleKeys.ColumnBreakBeforeKey, out val))
                    return val.Value;
                else
                    return false;
            }
            set
            {
                this.Style.SetValue(StyleKeys.ColumnBreakBeforeKey, value);
            }
        }

        #endregion

        #region public bool ColumnBreakAfter {get; set;}

        /// <summary>
        /// Gets or sets the split option for this visual component
        /// </summary>
        [PDFAttribute("column-break-after", Const.PDFStylesNamespace)]
        [PDFDesignable("Column Break After", Category = "Layout", Priority = 4, Type = "Boolean")]
        public bool ColumnBreakAfter
        {
            get
            {
                StyleValue<bool> val;
                if (this.HasStyle && this.Style.TryGetValue(StyleKeys.ColumnBreakAfterKey, out val))
                    return val.Value;
                else
                    return false;
            }
            set
            {
                this.Style.SetValue(StyleKeys.ColumnBreakAfterKey, value);
            }
        }

        #endregion


        //
        // data attributes
        //

        #region public string DataStyleIdentifier

        /// <summary>
        /// Gets the identifer for the style of this component that can uniquely identify any set of style attributes across a document
        /// </summary>
        [PDFAttribute("style-identifier",Const.PDFDataNamespace)]
        [PDFDesignable("Style Cache Key", Ignore = true)]
        public string DataStyleIdentifier
        {
            get;
            set;
        }

        #endregion

        //
        // ctor
        //

        protected VisualComponent(PDFObjectType type)
            : base(type)
        {
            
        }

        #region Databind()
        
        /// <summary>
        /// Inheritors should override this method to provide their own databing implementations.
        /// </summary>
        /// <param name="includeChildren">Flag to identifiy if children should be databound also</param>
        protected override void DoDataBind(PDFDataContext context, bool includeChildren)
        {
            if (includeChildren && this.HasStyle)
                this.Style.DataBind(context);
            base.DoDataBind(context, includeChildren);
        }

        #endregion

    }

    public class PDFVisualComponentList : ComponentWrappingList<VisualComponent>
    {
        public PDFVisualComponentList(ComponentList innerList)
            : base(innerList)
        {
        }

    }
}

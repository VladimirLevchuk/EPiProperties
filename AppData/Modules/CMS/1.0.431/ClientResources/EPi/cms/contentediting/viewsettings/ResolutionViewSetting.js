//>>built
define("epi/cms/contentediting/viewsettings/ResolutionViewSetting",["dojo/_base/declare","epi/cms/contentediting/_ViewSetting"],function(_1,_2){return _1([_2],{key:"resolution",usedForRendering:false,afterPreviewLoad:function(_3,_4){this.inherited(arguments);if(_3){var _5=_4?this._getPreviewResolution():null;_3.set("previewSize",_5);_3.set("previewClass",this.value?"epi-viewPort-"+this.value:"");}return null;},_getPreviewResolution:function(){var _6=null;var _7=this.value;if(_7){var _8=_7.split("x");if(_8.length==2){_6={"w":_8[0],"h":_8[1]};}}return _6;}});});
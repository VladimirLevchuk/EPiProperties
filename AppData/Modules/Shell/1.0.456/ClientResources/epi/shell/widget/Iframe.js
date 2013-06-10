//>>built
define("epi/shell/widget/Iframe",["dojo/_base/declare","dojo/_base/Deferred","dojo/_base/lang","dojo/_base/window","dojo/dom","dojo/dom-construct","dojo/dom-geometry","dojo/dom-style","dojo/has","dojo/io-query","dojo/on","dijit/_Widget","dijit/_TemplatedMixin","dijit/focus","epi/Url"],function(_1,_2,_3,_4,_5,_6,_7,_8,_9,_a,on,_b,_c,_d,_e){return _1("epi.shell.widget.Iframe",[_b,_c],{url:"about:blank",_triggeredExternally:false,templateString:"<iframe data-dojo-attach-point=\"iframe\" class=\"dijitReset\" src=\"${url}\" role=\"presentation\" frameborder=\"0\" style=\"width:100%;\"></iframe>",minHeight:10,maxHeight:Infinity,autoFit:false,visible:true,_setVisibleAttr:function(_f){_8.set(this.domNode,"display",_f?"block":"none");},isLoading:false,_isInspectable:null,_loadDeferred:null,onLoading:function(url){this._set("isLoading",true);},onUnload:function(url){this._set("isLoading",true);},onLoad:function(url,_10){this._set("isLoading",false);},buildRendering:function(){this.inherited(arguments);_5.setSelectable(this.domNode,false);var _11=function(_12){return typeof _12=="number"&&isFinite(_12);};_8.set(this.domNode,"minHeight",_11(this.minHeight)?this.minHeight+"px":"none");_8.set(this.domNode,"maxHeight",_11(this.maxHeight)?this.maxHeight+"px":"none");if(this.iframe.attachEvent){this.iframe.attachEvent("onload",_3.hitch(this,this._onIframeLoad));}else{this.connect(this.iframe,"onload",this._onIframeLoad);}},resize:function(_13){if(this.autoFit){return;}if(_13){_8.set(this.iframe,{width:_13.w+"px",height:_13.h+"px"});}},getDocument:function(){if(!this.isInspectable()){return null;}try{if(this.iframe.contentWindow){return this.iframe.contentWindow.document;}else{return null;}}catch(ex){return null;}},getWindow:function(){return this.iframe.contentWindow;},_onIframeLoad:function(_14){var url=null,_15;function _16(e){this.set("_isInspectable",false);if(this._focusHandle){this._focusHandle.remove();}if(this._mousedownHandle){this._mousedownHandle.remove();}this.onUnload(this.url);};if(this.isInspectable(true)){url=this.getLocation().href;this._focusHandle=_d.registerIframe(this.iframe);this._mousedownHandle=this.connect(this.getDocument(),"onmousedown",function(){on.emit(this.domNode,"mousedown",{bubbles:true,cancelable:true});});_15=this.getWindow();if(_15.attachEvent){_15.attachEvent("onbeforeunload",_3.hitch(this,_16));}else{this.connect(_15,"onunload",_16,this);}}this._set("url",url);if(url!=="about:blank"){if(this._loadDeferred){this._loadDeferred.resolve();this._loadDeferred=null;}this.onLoad(this.url,this._triggeredExternally);}this._triggeredExternally=false;if(this.autoFit){this._adjustSize(this._calculateActualSize());}},isInspectable:function(_17){if(!_17&&this._isInspectable!==null){return this._isInspectable;}try{var url=this.getLocation().href;return this._isInspectable=!!url;}catch(ex){}return this._isInspectable=false;},load:function(url,_18,_19){var def;if(this._loadDeferred){this._loadDeferred.cancel();}def=new _2();if(url){this._loadDeferred=def;var _1a=new _e(url,_18,_19);this.set("url",_1a.toString());}else{def.cancel();}return def;},reload:function(){return this.load(this.get("url"));},getCurrentQuery:function(){return _a.queryToObject(this.getWindow().location.search.substring(1));},getLocation:function(){return this.getWindow().location;},_getUrlAttr:function(){return this.url;},_setUrlAttr:function(url){this._triggeredExternally=true;this.onLoading(url);if((!_9("ie")||(_9("ie")>8))&&this.iframe.contentWindow){this.iframe.contentWindow.location.replace(url);}else{this.iframe.src=url;}this.url=url;},_calculateActualSize:function(){var doc=this.getDocument();function _1b(dir){if(doc&&doc.body&&doc.documentElement){return Math.max(doc.documentElement["client"+dir],doc.documentElement["scroll"+dir],doc.documentElement["offset"+dir],doc.body["scroll"+dir],doc.body["offset"+dir]);}return 0;};return {h:_1b("Height"),w:_1b("Width")};},_adjustSize:function(_1c){_8.set(this.iframe,"height",_1c.h+"px");_8.set(this.getWindow().document.body,"height","auto");}});});
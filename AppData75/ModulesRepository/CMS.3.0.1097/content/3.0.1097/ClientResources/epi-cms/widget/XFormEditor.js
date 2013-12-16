//>>built
define("epi-cms/widget/XFormEditor",["dojo/_base/declare","dojo/_base/event","dojo/_base/lang","dojo/_base/Deferred","dojo/when","dojo/dom-class","dojo/dom-style","dojo/dom-construct","dojo/query","dojo/html","dijit/focus","dijit/form/Button","epi/shell/widget/dialog/Dialog","epi/dependency","epi-cms/legacy/LegacyFormEditor","epi-cms/_ContentContextMixin","epi-cms/legacy/LegacyDialogPopup","epi/routes","epi-cms/widget/XFormPropertyWidget","epi/i18n!epi/cms/nls/episerver.cms.legacy.legacyformeditor","epi/i18n!epi/cms/nls/episerver.cms.widget.xformeditor"],function(_1,_2,_3,_4,_5,_6,_7,_8,_9,_a,_b,_c,_d,_e,_f,_10,_11,_12,_13,res,_14){return _1([_f,_10],{localization:_3.mixin(res,_14),destroyOnHide:true,editorWidgetClass:_13,store:null,stopEditOnBlur:true,templateString:"            <div class=\"dijit dijitReset dijitInline dijitLeft epi-xFormEditor\">                <div data-dojo-attach-point=\"output\" data-dojo-type=\"dijit/form/TextBox\" value=\"${localization.helptext}\"></div>                <div data-dojo-type=\"dijit/form/Button\" data-dojo-attach-point=\"openButton\" data-dojo-attach-event=\"onClick: openEditor\" data-dojo-props=\"label:'${localization.buttonlabel}'\"></div>                <a href=\"#\" data-dojo-attach-point=\"viewDataLink\" data-dojo-attach-event=\"click: _openViewDataDialog\" title=\"${localization.viewdata.tooltip}\" class=\"disabled\">${localization.viewdata.text}</a>            </div>",postMixInProperties:function(){this.inherited(arguments);var _15=_e.resolve("epi.storeregistry");this.store=this.store||_15.get("epi.cms.xform");},openEditor:function(){this.inherited(arguments);this.onFocus();},_createDialog:function(){if(this.contentLink){_3.mixin(this.params,{"contentLink":this.contentLink});}else{_5(this.getCurrentContext(),_3.hitch(this,function(_16){_3.mixin(this.params,{"contentLink":_16.id});}));}this.inherited(arguments);},_openViewDataDialog:function(evt){_2.stop(evt);if(_6.contains(this.viewDataLink,"disabled")){return;}this._showFormDataDialog("Edit/XFormViewData.aspx",this.contentLink,this.value);},_onCancel:function(){this.inherited(arguments);this.setDisplayValue(this.value);},_onDialogCancel:function(){this.inherited(arguments);this.setDisplayValue(this.value);},_showFormDataDialog:function(_17,_18,_19){var _1a=_12.getActionPath({id:_18,path:_17,moduleArea:"LegacyCMS",IsInLegacyWrapper:true,formid:_19}),_1b=new _11({url:_1a,dialogArguments:window.document,showCancelButton:true,features:{width:750,height:300},autoFit:true,showLoadingOverlay:false});this.connect(_1b,"onLoad",function(_1c){if(!_1c){return;}var h1=_9("h1[class=\"EP-prefix\"]",_1c.containerIframe.contentDocument.body);_8.create("span",{innerHTML:this.localization.viewdata.forms+" >"},h1.parent()[0],"first");var _1d=_9("select[id$=\"SelectForm\"]",_1c.containerIframe.contentDocument.body);if(_1d){_7.set(_1d.parent()[0],"display","none");}var _1e=_9("input[type=\"checkbox\"][id$=\"ShowResultFromAllPages\"]",_1c.containerIframe.contentDocument.body);if(_1e){_7.set(_1e.parent()[0],"display","none");}});_1b.show();},setDisplayValue:function(_1f){if(!_1f){this.output.set("value",this.localization.helptext);_6.add(this.viewDataLink,"disabled");return;}_4.when(this.store.query({id:_1f}),_3.hitch(this,function(_20){if(_20&&_20.name){this.output.set("value",_20.name);this.contentLink&&_6.remove(this.viewDataLink,"disabled");}else{this.set("value",null);}this.onBlur();}));}});});
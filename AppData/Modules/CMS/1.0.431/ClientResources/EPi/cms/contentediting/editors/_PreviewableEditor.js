//>>built
require({cache:{"url:epi/cms/contentediting/editors/templates/_PreviewableEditor.html":"<div class=\"dijitReset dijitInline epi-previewableTextBox-wrapper\">\r\n    <span data-dojo-attach-point=\"labelNode\" class=\"epi-previewableTextBox-text dojoxEllipsis dijitInline\"></span>\r\n    <a href=\"#\" data-dojo-attach-point=\"changeNode, focusNode\" class=\"epi-functionLink\">${changeLabel}</a>\r\n</div>\r\n"}});define("epi/cms/contentediting/editors/_PreviewableEditor",["dojo/_base/array","dojo/_base/event","dojo/_base/declare","dojo/_base/lang","dojo/on","dojo/dom-class","dojo/dom-construct","dojo/dom-style","dijit","dijit/_CssStateMixin","dijit/_Widget","dijit/_TemplatedMixin","dijit/_WidgetsInTemplateMixin","dijit/form/ValidationTextBox","epi","dojo/text!./templates/_PreviewableEditor.html"],function(_1,_2,_3,_4,on,_5,_6,_7,_8,_9,_a,_b,_c,_d,_e,_f){return _3("epi.cms.contentediting.editors._PreviewableEditor",[_a,_9,_b,_c],{value:null,changeLabel:_e.resources.action.change,templateString:_f,control:null,controlParams:[],state:"",_setLabelValueAttr:{node:"labelNode",type:"innerHTML"},_setIsEmptyAttr:function(_10){this._set("isEmpty",_10);if(_10){_5.add(this.domNode,"epi-state-empty");}else{_5.remove(this.domNode,"epi-state-empty");}},_setValueAttr:function(_11){this._set("value",_11);this.control.set("value",_11);this.set("labelValue",_11);this.set("isEmpty",!_11);},onChange:function(val){},buildRendering:function(){this.inherited(arguments);if(!this.control){this.control=new _d();}this.control.placeAt(this.domNode,"first");},postCreate:function(){this.inherited(arguments);this._setDisplay(false);this._connects.push(on(this.labelNode,"click",_4.hitch(this,"_onChangeNodeClick")));this._connects.push(on(this.changeNode,"click",_4.hitch(this,"_onChangeNodeClick")));this._connects.push(on(this.control,"Change",_4.hitch(this,"_onControlChange")));this._connects.push(on(this.control,"onBlur",_4.hitch(this,"_onControlBlur")));this.control.watch("state",_4.hitch(this,function(_12,old,_13){this.set("state",_13);}));this.control.validate();this.set("state",this.control.state);_1.forEach(this.controlParams,function(_14){this.control.set(_14,this.get(_14));},this);},destroyRecursive:function(){if(this.control){this.control.destroyRecursive();}delete this.control;this.inherited(arguments);},onBlur:function(){this._setDisplay(false);},_setDisplay:function(_15){if(!_15&&!this.validate()){return;}this.showControl=_15;_7.set(this.labelNode,"display",_15?"none":"");_7.set(this.control.domNode,"display",_15?"":"none");if(!this.readOnly){_7.set(this.changeNode,"display",_15?"none":"");}},focus:function(){if(this.showControl){this.control.focus();}else{this.changeNode.focus();}},_onControlChange:function(_16){this._set("value",_16);this.set("labelValue",_16);this.set("isEmpty",!_16);this.onChange(_16);},_onControlBlur:function(){this._setDisplay(false);},_onChangeNodeClick:function(e){_2.stop(e);this._setDisplay(true&&!this.readOnly);_8.selectInputText(this.control.focusNode);},_setReadOnlyAttr:function(_17){this._set("readOnly",_17);_7.set(this.changeNode,"display",this.readOnly?"none":"");this.readOnly&&this._setDisplay(false);},validate:function(){return this.control.validate();},isValid:function(){return this.control.isValid();},getErrorMessage:function(){var _18=this.get("state")!=="Error";return _18?"":this.control.invalidMessage;}});});
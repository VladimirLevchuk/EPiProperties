//>>built
require({cache:{"url:epi/cms/form/templates/BooleanRadioButtons.html":"<div class=\"dijit dijitReset dijitInline\" waiRole=\"presentation\" id=\"widget_${id}\" >\n    <input type=\"radio\" dojoType=\"dijit.form.RadioButton\" dojoAttachPoint=\"trueRadio\" id=\"trueRadio_${id}\" name=\"radio_${id}\" value=\"true\" /><label for=\"trueRadio_${id}\">${trueLabel}</label>\n    <input type=\"radio\" dojoType=\"dijit.form.RadioButton\" dojoAttachPoint=\"falseRadio\" id=\"falseRadio_${id}\" name=\"radio_${id}\" value=\"false\" /><label for=\"falseRadio_${id}\">${falseLabel}</label>\n</div>\n"}});define("epi/cms/form/BooleanRadioButtons",["dojo","dijit","epi/i18n!epi/cms/nls/episerver.cms.form","dijit/_Widget","dijit/_TemplatedMixin","dijit/_WidgetsInTemplateMixin","dojo/text!./templates/BooleanRadioButtons.html"],function(_1,_2,_3,_4,_5,_6,_7){return _1.declare("epi.cms.form.BooleanRadioButtons",[_4,_5,_6],{templateString:_7,trueLabel:_3.truelabel,falseLabel:_3.falselabel,value:true,_setValueAttr:function(_8){this.value=_8;if(_8){_2.byId(this.trueRadio.id).set("checked",true);_2.byId(this.falseRadio.id).set("checked",false);}else{_2.byId(this.trueRadio.id).set("checked",false);_2.byId(this.falseRadio.id).set("checked",true);}},_getValueAttr:function(){return _2.byId(this.trueRadio.id).get("checked")===true;}});});
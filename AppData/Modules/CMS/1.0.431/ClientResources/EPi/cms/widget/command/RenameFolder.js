//>>built
define("epi/cms/widget/command/RenameFolder",["dojo/_base/declare","epi/i18n!epi/cms/nls/episerver.cms.components.sharedblockscomponent","epi/cms/contentediting/ContentActionSupport","epi/shell/command/_Command"],function(_1,_2,_3,_4){return _1([_4],{label:_2.contextmenu.rename,contentActionSupport:null,postscript:function(){this.inherited(arguments);this.contentActionSupport=this.contentActionSupport||_3;},_execute:function(){this.model.labelWidget.edit();},_onModelChange:function(){var _5=this.model&&this.model.labelWidget&&this.contentActionSupport.hasAccess(this.model.item.accessMask,_3.accessLevel[_3.action.Edit]);this.set("canExecute",_5);}});});
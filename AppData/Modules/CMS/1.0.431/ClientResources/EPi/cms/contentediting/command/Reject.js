//>>built
define("epi/cms/contentediting/command/Reject",["dojo/_base/declare","epi/shell/command/_Command","epi/cms/contentediting/ContentActionSupport","epi/cms/contentediting/command/_ChangeContentStatus","epi/i18n!epi/cms/nls/episerver.cms.contentediting.toolbar.buttons"],function(_1,_2,_3,_4,_5){return _1("epi.cms.contentediting.command.Reject",[_4],{name:"reject",label:_5.reject.label,tooltip:_5.reject.title,iconClass:"epi-iconStop",action:_3.action.Reject,_execute:function(){return this.inherited(arguments);},_onModelChange:function(){this.inherited(arguments);var _6=this.model.contentData,_7=_6.status,_8=_3.versionStatus,_9=(_7==_8.CheckedIn)&&this.model.canChangeContent(_3.action.Publish);this.set("canExecute",_9);this.set("isAvailable",_9);}});});
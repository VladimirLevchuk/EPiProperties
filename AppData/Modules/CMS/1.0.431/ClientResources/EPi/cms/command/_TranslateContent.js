//>>built
define("epi/cms/command/_TranslateContent",["dojo/_base/declare","dojo/topic","epi/shell/command/_Command","epi/i18n!epi/cms/nls/episerver.cms.contentediting.toolbar.buttons"],function(_1,_2,_3,_4){return _1([_3],{label:_4.translate.label,executingLabel:_4.translate.executinglabel,tooltip:_4.translate.title,iconClass:"dijitIconEdit",category:"context",_executeCommand:function(_5){_2.publish("/epi/shell/action/changeview","epi/cms/component/CreateLanguageBranch",null,{contentData:_5});},_canExecute:function(_6,_7,_8){var _9=_7.language&&!!_8&&_8.isTranslationNeeded&&_8.isPreferredLanguageAvailable&&_8.hasTranslationAccess&&!(_6.isWastebasket||_6.isDeleted);var _a=!!_8&&_8.isTranslationNeeded;this.set("canExecute",_9);this.set("isAvailable",_a);}});});
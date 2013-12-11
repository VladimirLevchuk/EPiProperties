//>>built
define("epi-cms/component/SiteTreeModel",["dojo/_base/array","dojo/_base/declare","dojo/Stateful","dojo/Deferred","dojo/when","dojo/_base/lang","dojo/_base/connect","dojo/cookie","epi/dependency","epi/string"],function(_1,_2,_3,_4,_5,_6,_7,_8,_9,_a){return _2([_3],{query:null,showAllLanguages:true,location:document.location,profile:null,store:null,constructor:function(){this.query={allLanguages:this.showAllLanguages};},postscript:function(){this.inherited(arguments);this.profile=this.profile||_9.resolve("epi.shell.Profile");_7.subscribe("/epi/cms/contentdata/updated",_6.hitch(this,function(){_5(this.getCurrentSite(),_6.hitch(this,function(_b){this.onItemChildrenReload({siteUrl:_b.currentSite});}));}));},getRoot:function(_c,_d){_c({});},getIdentity:function(_e){var id=this.store.getIdentity(_e);if(!id&&!_e.isLanguageNode){id="root";}return id;},onItemChildrenReload:function(_f){},mayHaveChildren:function(_10){if(!_10.isLanguageNode){return true;}return false;},getLabel:function(_11){return _11.name;},getChildren:function(_12,_13){_5(this.store.query(_6.mixin({siteUrl:_12.url},this.query)),_13);},_setQuery:function(q){this.query=q;this.onItemChildrenReload({});},_showAllLanguagesSetter:function(_14){this.showAllLanguages=_14;this._setQuery({allLanguages:_14});},getCurrentSite:function(){var def=new _4();_5(this.profile.getContentLanguage(),_6.hitch(this,function(_15){if(_15){_5(this.store.get(),_6.hitch(this,function(_16){var _17=null;var _18=null;_1.some(_16,function(_19){return _1.some(_19.hosts,function(_1a){if(_1a==="*"){_18=_19;return true;}});});var _1b=this.location.host.toLowerCase();var _1c=_1.some(_16,function(_1d){return _1.some(_1d.hosts,function(_1e){if(_1b==_1e.toLowerCase()){_17={currentSite:_1d.url,currentEditLanguageId:_1d.url+_15};return true;}});});if(!_1c&&_18){_17={currentSite:_18.url,currentEditLanguageId:_18.url+_15};}if(_17){def.resolve(_17);}else{def.cancel();}}),function(){def.reject(null);});}else{def.reject(null);}}));return def;},getAllLanguagesForSite:function(_1f){var def=new _4();_5(this.store.query({siteUrl:_1f,allLanguages:true}),function(_20){def.resolve(_20);});return def;},getAllLanguagesForCurrentSite:function(){var def=new _4();_5(this.getCurrentSite(),_6.hitch(this,function(_21){this.getAllLanguagesForSite(_21.currentSite).then(function(_22){def.resolve(_22);});}),function(_23){def.reject(_23);});return def;}});});
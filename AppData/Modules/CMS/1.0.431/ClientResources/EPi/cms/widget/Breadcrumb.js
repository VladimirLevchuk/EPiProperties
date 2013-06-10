//>>built
define("epi/cms/widget/Breadcrumb",["dojo/_base/array","dojo/_base/declare","dojo/_base/Deferred","dojo/_base/lang","dojo/dom-class","dojo/dom-construct","dojo/dom-geometry","dojo/dom-style","dojo/aspect","dojo/query","dojo/NodeList-manipulate","dojo/topic","dijit/_Widget","dijit/_TemplatedMixin","dijit/layout/_LayoutWidget","epi/dependency","epi/shell/_HierarchicalModelMixin","epi/cms/core/ContentReference"],function(_1,_2,_3,_4,_5,_6,_7,_8,_9,_a,_b,_c,_d,_e,_f,_10,_11,_12,_13){return _2("epi.cms.widget.Breadcrumb",[_f,_e,_11],{templateString:"<ul data-dojo-attach-point='containerNode'></ul>",contentLink:null,store:null,showCurrentNode:true,showLastBracket:false,displayAsText:true,minimumItemCount:null,baseClass:"epi-breadCrumbs",_resizeListener:null,_visibleItems:[],_currentContent:null,_ancestors:null,postMixInProperties:function(){var _14=_10.resolve("epi.storeregistry");this.store=this.store||_14.get("epi.cms.content.light");this.minimumItemCount=this.minimumItemCount||2;},startup:function(){this._addResizeListener();},destroy:function(){if(this._resizeListener){this._resizeListener.remove();}this.destroyDescendants();this.inherited(arguments);},_addResizeListener:function(){if(this._resizeListener){return;}var _15=this.getParent(),_16=_15;while(_16&&!_16.isLayoutContainer&&_16.getParent()){_16=_16.getParent();}if(_16&&_16!==_15){this._resizeListener=_9.after(_16,"resize",_4.hitch(this,function(){var _17=_7.getMarginBox(this.domNode);this.resize(_17);}));}},resize:function(_18){if(!_18&&this._resizeListener){return;}else{this.layout();}},layout:function(){this._visibleItems=[];_3.when(this._buildPath(),_4.hitch(this,function(){var _19=_7.getContentBox(this.domNode).w;if(_19>this._availableWidth){var _1a=this._availableWidth-_7.getMarginBox(this._leadingItem.domNode).w;this._ellipsisize(0,_1a);}}));},_setContentLinkAttr:function(_1b){this._set("contentLink",_1b);this._currentContent=null;this._ancestors=null;this.layout();},_buildPath:function(){var _1c=this.get("contentLink"),def=new _3(),_1d="";if(this._currentContent&&this._ancestors){this._createAllItems();def.resolve(_1d);}else{if(_1c){var _1e=new _12(_1c);var _1f=_1e.createVersionUnspecificReference().toString();_3.when(this.store.get(_1f),_4.hitch(this,function(_20){this.getAncestors(_1f,_4.hitch(this,function(_21){this._currentContent=_20;this._ancestors=_21;this._createAllItems();def.resolve(_1d);}));}));}else{def.resolve(_1d);}}return def;},_createAllItems:function(){this._cleanUp();var _22=[];for(var i=this._ancestors.length-1;i>=0;i--){var _23=this._ancestors[i];if(!_23.parentLink){continue;}_22.push(_23);if(_23.isSubRoot){break;}}_22.reverse();var _24=_7.getContentBox(this.domNode).w;this._availableWidth=_24>=0?_24:0;_1.forEach(_22,_4.hitch(this,function(_25){this._createItem(_25,true);}));if(this.showCurrentNode){this._createItem(this._currentContent,this.showLastBracket);}},_cleanUp:function(){this.destroyDescendants();this._leadingItem=null;this._visibleItems=[];},_createItem:function(_26,_27){var _28=null,li=_6.create("li");if(this.displayAsText){_28=_6.create("span");}else{_28=_6.create("a",{href:"#",id:_26.contentLink});_28.onclick=function(_29){var _2a=_29.target.id;var _2b={uri:_26.uri};_c.publish("/epi/shell/context/request",_2b,{sender:this});};}_a(_28).text(_26.name);_6.place(_28,li,"last");if(_27){var _2c=_6.create("span",{innerHTML:" &gt; ","class":"epi-breadCrumbsSeparator"});_6.place(_2c,li,"last");}this._addAndLayout(li);},_addAndLayout:function(_2d){var _2e=new _d({},_2d);this._visibleItems.push(_2e);this.addChild(_2e);var _2f=this._getTotalVisibleItemsSize();if(_2f>this._availableWidth){this._ensureLeadingItem();while(_2f>this._availableWidth&&this._visibleItems.length>this.minimumItemCount){var _30=this._visibleItems.splice(0,1)[0];_8.set(_30.domNode,"display","none");_2f=this._getTotalVisibleItemsSize();}}},_getTotalVisibleItemsSize:function(){var _31=0;if(this._leadingItem){_31+=_7.getMarginBox(this._leadingItem.domNode).w;}_1.forEach(this._visibleItems,function(_32){_31+=_7.getMarginBox(_32.domNode).w;});return _31;},_ensureLeadingItem:function(){if(this._leadingItem){return;}var _33=_6.create("li"),_34=_6.create("span",{innerHTML:"..."}),_35=_6.create("span",{innerHTML:" &gt; ","class":"epi-breadCrumbsSeparator"});_6.place(_34,_33,"last");_6.place(_35,_33,"last");this._leadingItem=new _d({},_33);this.addChild(this._leadingItem,0);},_ellipsisize:function(_36,_37){if(_36>=this._visibleItems.length){return;}var _38=this._visibleItems.length-_36,_39=Math.floor(_37/_38),_3a=this._visibleItems[_36],_3b=_7.getMarginBox(_3a.domNode).w;if(_3b<=_39){this._ellipsisize(_36+1,_37-_3b);}else{var _3c=_a(this.displayAsText?"span":"a",_3a.domNode)[0],_3d=_a("span.epi-breadCrumbsSeparator",_3a.domNode)[0],_3e=_39-_7.getMarginBox(_3d).w;if(_3e<0){_3e=0;}_8.set(_3c,"width",_3e+"px");_5.add(_3c,"dojoxEllipsis");this._ellipsisize(_36+1,_37-_39);}}});});
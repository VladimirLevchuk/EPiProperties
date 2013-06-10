//>>built
define("epi/shell/widget/layout/_ComponentSplitter",["dojo/_base/declare","dojo/_base/event","dojo/_base/lang","dojo/_base/window","dojo/dom-geometry","dojo/dom-style","dojo/keys","dojo/on","dojo/touch","dijit/_WidgetBase","dijit/_TemplatedMixin","dijit/_CssStateMixin"],function(_1,_2,_3,_4,_5,_6,_7,on,_8,_9,_a,_b){return _1("epi.shell.widget.layout._ComponentSplitter",[_9,_a,_b],{baseClass:"epi-gadgetGutter",templateString:"<div data-dojo-attach-event=\"onkeypress:_onKeyPress,press:_startDrag\" role=\"separator\" tabindex=\"0\"></div>",disabled:false,constructor:function(){this._handlers=[];},_startDrag:function(e){if(this.disabled){return;}var _c=this.domNode.style,_d=e.pageY,_e=this.child.domNode,_f=_6.getComputedStyle(_e),_10=_5.getMarginExtents(_e,_f).h,_11=_5.getMarginBox(_e,_f).h,max=this.child.maxHeight||Infinity,min=this.child.minHeight||0,_12=parseInt(_c.top,10),_13=_3.hitch(this.container,"_layoutChildren",this.child),doc=_4.doc;this._handlers=this._handlers.concat([on(doc,_8.move,this._drag=function(e,_14){var _15=e.pageY-_d,_16=_15+_11,_17=Math.max(Math.min(_16,max),min+_10);_13(_17,_14);_c.top=_15+_12+_17-_16+"px";}),on(doc,"dragstart",_2.stop),on(_4.body(),"selectstart",_2.stop),on(doc,_8.release,_3.hitch(this,"_stopDrag"))]);_2.stop(e);},_stopDrag:function(e){try{this._drag(e);this._drag(e,true);}finally{this._cleanupHandlers();delete this._drag;}},_onKeyPress:function(e){var _18=1;switch(e.charOrCode){case _7.UP_ARROW:_18=-1;break;case _7.DOWN_ARROW:break;default:return;}var _19=_5.getMarginSize(this.child.domNode).h+_18;this.container._layoutChildren(this.child,Math.max(Math.min(_19,this.child.maxSize),this.child.minSize));_2.stop(e);},_cleanupHandlers:function(){var h;while(h=this._handlers.pop()){h.remove();}},destroy:function(){this._cleanupHandlers();delete this.child;delete this.container;this.inherited(arguments);}});});
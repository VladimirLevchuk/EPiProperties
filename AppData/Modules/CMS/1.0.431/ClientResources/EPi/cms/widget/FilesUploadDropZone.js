//>>built
require({cache:{"url:epi/cms/widget/templates/FilesUploadDropZone.html":"<div class=\"epi-filesUploadDropZone\">\r\n    <div>\r\n        <span data-dojo-attach-point=\"description\">${res.description}</span>\r\n    </div>\r\n</div>"}});define("epi/cms/widget/FilesUploadDropZone",["dojo/_base/declare","dojo/_base/lang","dojo/dom-class","dijit/_Widget","dijit/_TemplatedMixin","epi/i18n!epi/cms/nls/episerver.cms.widget.uploadmultiplefiles.dropzone","dojo/text!./templates/FilesUploadDropZone.html"],function(_1,_2,_3,_4,_5,_6,_7){return _1("epi.cms.widget.FilesUploadDropZone",[_4,_5],{res:_6,templateString:_7,dragStartCssClass:"epi-dragStart",dragOverCssClass:"epi-dragOver",outsideDomNode:null,postCreate:function(){this.inherited(arguments);if(this.outsideDomNode){this.connect(this.outsideDomNode,"dragover",_2.hitch(this,this._onDragOverOutside));this.connect(this.outsideDomNode,"dragleave",_2.hitch(this,this._onDragLeave));this.connect(this.outsideDomNode,"dragend",_2.hitch(this,this._onDragLeave));this.connect(this.outsideDomNode,"drop",_2.hitch(this,this._onDragLeave));}this.connect(this.domNode,"dragover",_2.hitch(this,this._onDragOver));this.connect(this.domNode,"dragleave",_2.hitch(this,this._onDragLeave));this.connect(this.domNode,"dragend",_2.hitch(this,this._onDragLeave));this.connect(this.domNode,"drop",_2.hitch(this,this._onDrop));},_onDragOverOutside:function(_8){_8.preventDefault();_3.add(this.domNode,this.dragStartCssClass);},_onDragOver:function(_9){_9.preventDefault();_3.remove(this.domNode,this.dragStartCssClass);_3.add(this.domNode,this.dragOverCssClass);},_onDragLeave:function(_a){_a.preventDefault();this._removeAllCssClasses();},onDrop:function(_b,_c){},_onDrop:function(_d){_d.preventDefault();this._removeAllCssClasses();this.onDrop(_d,_d.dataTransfer.files);},_removeAllCssClasses:function(){_3.remove(this.domNode,this.dragStartCssClass);_3.remove(this.domNode,this.dragOverCssClass);}});});
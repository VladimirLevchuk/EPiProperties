//>>built
require({cache:{"url:epi/packaging/templates/PackageUpload.htm":"<div>\r\n    <!-- Upload form -->\r\n    <form method=\"post\" action=\"${_uploadUrl}\" enctype=\"multipart/form-data\">\r\n        <div class=\"uploaderButton\" >\r\n            <input dojoAttachPoint=\"_uploaderInput\" type=\"file\" />\r\n        </div>\r\n        <input type=\"submit\" dojoAttachPoint=\"_installButton\" label=\"${res.buttoninstall}\" dojoType=\"dijit.form.Button\" />\r\n        <input type=\"reset\" dojoAttachPoint=\"_clearButton\" label=\"${res.buttonclear}\" dojoType=\"dijit.form.Button\" />\r\n        <div class=\"epi-paddingVertical-small\">\r\n            <!-- Selected files -->\r\n            <div dojoAttachPoint=\"_fileListNode\"></div>\r\n            <!-- Uploaded file -->\r\n            <div dojoAttachPoint=\"_uploadResultsNode\"></div>\r\n        </div>\r\n        <input type=\"hidden\" dojoAttachPoint=\"_uploadType\" name=\"uploadType\" />\r\n    </form>\r\n</div>\r\n"}});define("epi/packaging/PackageUpload",["dojo","dijit","dijit/_Widget","dijit/_TemplatedMixin","dijit/_WidgetsInTemplateMixin","dijit/layout/TabContainer","dijit/layout/ContentPane","epi/routes","epi/packaging/UploadResults","epi/packaging/SelectedFiles","epi/packaging/RestartSite","dojox/widget/Standby","epi/shell/widget/HelpButton","dojox/form/Uploader","dojox/form/uploader/plugins/IFrame","dojo/text!./templates/PackageUpload.htm","epi/i18n!epi/packaging/nls/EPiServer.Packaging.UI.PackageUpload"],function(_1,_2,_3,_4,_5,_6,_7,_8,_9,_a,_b,_c,_d,_e,_f,_10,res){return _1.declare("epi.packaging.PackageUpload",[_3,_4,_5],{res:res,successMessageClass:"successInstall",failureMessageClass:"failureInstall",templateString:_10,antiForgeryData:null,_uploadUrl:null,_uploader:null,_uploadResultsNode:null,_installButton:null,_clearButton:null,_fileListNode:null,_fileList:null,_uploadResults:null,_standByWidget:null,_uploaderResetRequired:false,postMixInProperties:function(){this._uploadUrl=_8.getActionPath({moduleArea:"EPiServer.Packaging.UI",controller:"AddOns",action:"Upload"});this.inherited(arguments);},startup:function(){if(this._started){return;}this._uploader=new dojox.form.Uploader({label:this.res.buttonselectpackage,multiple:true},this._uploaderInput);_1.style(this._uploader.domNode,{width:"200px"});this._uploader.inputNodeFontSize=4;this._uploader.btnSize={w:200,h:25};this._uploaderResetRequired=true;this._uploader.startup();this._uploadType.value=this._uploader.uploadType;if(this.antiForgeryData){_1.place(this.antiForgeryData.GetTokenNode(),this._clearButton.domNode,"after");}this._fileList=new _a({uploader:this._uploader},this._fileListNode);this._fileList.startup();this._standByWidget=new _c({target:this._fileList.listTable});document.body.appendChild(this._standByWidget.domNode);this._standByWidget.startup();_1.connect(this._uploader,"onError",this,this._onUploaderError);_1.connect(this._uploader,"onComplete",this,this._onUploadComplete);_1.connect(this._uploader,"onChange",this,this._onUploadChange);_1.connect(this._clearButton,"onClick",this,this._onClear);_1.connect(this._installButton,"onClick",this,this._onInstall);this._disableButtons(true);this.inherited(arguments);},updateView:function(){if(this._uploaderResetRequired){this._onClear();this._uploaderResetRequired=false;}if(this._uploadResults){this._uploadResults.destroyRecursive(false);}},onSiteRestartRequired:function(){},onError:function(_11){},onSuccess:function(_12){},onModuleActionPerformed:function(){},_onClear:function(){this._uploader.reset();this._disableButtons(true);this.onModuleActionPerformed();},_onInstall:function(){this._standByWidget.show();this.onModuleActionPerformed();},_onUploaderError:function(evt){this._standByWidget.hide();this.onError([this.res.uploaderrormessage]);var _13=evt.headers;if(_13&&_13.indexOf("X-EPiLogOnScreen")!=-1){window.location.reload();}},_onUploadComplete:function(_14){this._standByWidget.hide();this._disableButtons(true);this._showUploadResults(_14);this.onSiteRestartRequired();},_onUploadChange:function(_15){this._standByWidget.hide();if(_15.length>0){this._disableButtons(false);}if(this._uploadResults){this._uploadResults.destroyRecursive(false);}},_disableButtons:function(_16){this._clearButton.set("disabled",_16);this._installButton.set("disabled",_16);},_showUploadResults:function(_17){if(this._uploadResults){this._uploadResults.destroyRecursive(false);}if(_17.uploadedFiles&&_17.uploadedFiles.length>0){var _18=_1.map(_17.uploadedFiles,function(_19,i){_19.index=i+1;_19.sizeStr=this._uploader.convertBytes(_19.packageFileLength).value;return _19;},this);var _1a=_17.installationFailCount==0;if(!_1a){var _1b=_1.replace(this.res.failuremessage,{count:_17.installationFailCount});this.onError([_1b]);}else{var _1c=_1.replace(this.res.successmessage,{count:_17.installationSuccessCount});this.onSuccess([_1c]);}this._uploadResults=new _9({files:_18});this._uploadResultsNode.appendChild(this._uploadResults.domNode);this._uploadResults.startup();_1.forEach(_17.uploadedFiles,function(_1d,i){if(_1d.packageInfo&&_1d.packageInfo.id=="EPiServer.Packaging"){_1.publish("onReloadRequired");}});}}});});
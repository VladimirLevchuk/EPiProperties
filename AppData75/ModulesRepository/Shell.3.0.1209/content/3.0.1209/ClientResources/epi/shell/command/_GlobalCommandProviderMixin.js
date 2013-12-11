//>>built
define("epi/shell/command/_GlobalCommandProviderMixin",["dojo/_base/array","dojo/_base/declare","dojo/_base/lang","epi/shell/command/_CommandProviderMixin","epi/dependency"],function(_1,_2,_3,_4,_5){return _2([_4],{commandKey:null,commandProviders:null,_consumer:null,_currentCommandModel:null,_providerWatch:null,_initialized:false,initializeCommandProviders:function(){if(this.initialized||!this.commandKey||!this.getConsumer){return;}this._consumer=this.getConsumer();if(!this._consumer){return;}this.commandRegistry=this.commandRegistry||_5.resolve("epi.globalcommandregistry");this.commandProviders=this.commandRegistry.get(this.commandKey,true);_1.forEach(this.commandProviders.providers,function(_6){this._consumer.addProvider(_6);},this);this._providerWatch=this.commandProviders.watch("providers",_3.hitch(this,this.onProvidersChanged));this.initialized=true;},updateCommandModel:function(_7){this._currentCommandModel=_7;_1.forEach(this.commandProviders.providers,function(_8){if(_8.updateCommandModel){_8.updateCommandModel(_7);}},this);},onProvidersChanged:function(_9,_a,_b){if(_a){_1.forEach(_a,this._consumer.removeProvider,this._consumer);}if(_b){_1.forEach(_b,function(_c){this._consumer.addProvider(_c);if(_c.updateCommandModel){_c.updateCommandModel(this._currentCommandModel);}},this);}},destroy:function(){if(this._consumer&&this.commandProviders){_1.forEach(this.commandProviders.providers,this._consumer.removeProvider,this);}this._providerWatch&&this._providerWatch.unwatch();this.inherited(arguments);}});});
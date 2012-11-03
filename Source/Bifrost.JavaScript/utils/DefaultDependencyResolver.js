﻿Bifrost.namespace("Bifrost", {
    DefaultDependencyResolver: function () {
        var self = this;

        this.doesNamespaceHave = function(namespace, name) {
            return namespace.hasOwnProperty(name);
        };

        this.doesNamespaceHaveScriptReference = function(namespace, name) {
            if( namespace.hasOwnProperty("_scripts") && Bifrost.isArray(namespace._scripts)) {
                for( var i=0; i<namespace._scripts.length; i++ ) {
                    var script = namespace._scripts[i];
                    if( script === name ) {
                        return true;
                    }
                }
            }
            return false;
        };

        this.loadScriptReference = function(namespace, name) {
            require(name);
        };


        this.canResolve = function (namespace, name) {
            var current = namespace;
            while (current != null) {
                if (self.doesNamespaceHave(current, name)) {
                    return true;
                }
                if (self.doesNamespaceHaveScriptReference(current,name)) {
                    return true;
                }
                current = current.parent;
            }

            return false;
        };

        this.resolve = function (namespace, name) {
            var current = namespace;
            while (current != null) {
                if (self.doesNamespaceHave(current,name)) {
                    return current[name];
                }
                if (self.doesNamespaceHaveScriptReference(current,name)) {
                    self.loadScriptReference(namespace, name);
                    if (self.doesNamespaceHave(current,name)) {
                        return current[name];
                    }
                }
                current = current.parent;
            }

            return null;
        };
    }
});

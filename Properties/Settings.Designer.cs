﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FIR.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Persist Security Info=False;User ID=siebel;Password=Qwer1234;Initial Catalog=sieb" +
            "eldb;Server=sbl16dev")]
        public string SiebelDbConnectionString {
            get {
                return ((string)(this["SiebelDbConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>BrowserScripts:02 Applet Browser Script,05 Application Browser Script,08 BC Browser Script</string>
  <string>ServerScrips:02 Applet Browser Script,03 Applet Server Script,06 Application Server Script,09 BC Server Script,16 BS Server function</string>
  <string>Code:02 Applet Browser Script,03 Applet Server Script,05 Application Browser Script,06 Application Server Script,08 BC Browser Script,09 BC Server Script,15 BS Browser function,16 BS Server function</string>
</ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection GroupsOfTypes {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["GroupsOfTypes"]));
            }
        }
    }
}
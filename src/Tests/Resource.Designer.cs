﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tests {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Tests.Resource", typeof(Resource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;ns0:BucketEntry xmlns:ns0=&quot;https://developer.kramp.com/bucketclaimcheck/2020/03/26&quot;&gt;
        ///  &lt;TargetInfo&gt;
        ///    &lt;AccountId&gt;0003505004504&lt;/AccountId&gt;
        ///    &lt;Name&gt;Marc Weber&lt;/Name&gt;
        ///  &lt;/TargetInfo&gt;
        ///  &lt;ResourcSourceInfo&gt;
        ///    &lt;BucketName&gt;biztalksample&lt;/BucketName&gt;
        ///    &lt;ResourceName&gt;Sample_Pricat.xml&lt;/ResourceName&gt;
        ///  &lt;/ResourcSourceInfo&gt;
        ///&lt;/ns0:BucketEntry&gt;.
        /// </summary>
        internal static string GoogleBucketEntry_1 {
            get {
                return ResourceManager.GetString("GoogleBucketEntry_1", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot; standalone=&quot;yes&quot;?&gt;
        ///&lt;message&gt;
        ///    &lt;defaults&gt;
        ///        &lt;data_element id=&quot;0065&quot; value=&quot;PRICAT&quot;/&gt;
        ///        &lt;data_element id=&quot;0052&quot; value=&quot;D&quot;/&gt;
        ///        &lt;data_element id=&quot;0054&quot; value=&quot;96A&quot;/&gt;
        ///        &lt;data_element id=&quot;0051&quot; value=&quot;UN&quot;/&gt;
        ///    &lt;/defaults&gt;
        ///    &lt;segment id=&quot;UNH&quot; maxrepeat=&quot;1&quot; required=&quot;true&quot;/&gt;
        ///    &lt;segment id=&quot;BGM&quot; maxrepeat=&quot;1&quot; required=&quot;true&quot;/&gt;
        ///    &lt;segment id=&quot;DTM&quot; maxrepeat=&quot;35&quot; required=&quot;true&quot;/&gt;
        ///    &lt;segment id=&quot;ALI&quot; maxrepeat=&quot;5&quot;/&gt;
        ///    &lt;segment id=&quot;F [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string GoogleBucketResult {
            get {
                return ResourceManager.GetString("GoogleBucketResult", resourceCulture);
            }
        }
    }
}

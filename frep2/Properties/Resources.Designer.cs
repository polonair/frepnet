﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.5420
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace frep2.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("frep2.Properties.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to &lt;html&gt;
        ///&lt;head&gt;
        ///	&lt;title&gt;&lt;/title&gt;
        ///&lt;/head&gt;
        ///&lt;body&gt;
        ///	&lt;h1&gt;Results for: {{fundCategory}}&lt;/h1&gt;
        ///	&lt;table border = 1 &gt;
        ///		&lt;tr&gt;
        ///			&lt;th&gt; Note 1&lt;/th&gt;
        ///			&lt;th&gt;Fund Name&lt;/th&gt;
        ///			&lt;th&gt;Value Research Rating as on Today&lt;/th&gt;
        ///			&lt;th&gt;Total Bond Sales in Rs (Crores) as on 3.30pm Today&lt;/th&gt;
        ///			&lt;th&gt;Performance Score Rank&lt;/th&gt;
        ///			&lt;th&gt;Yesterday NAV&lt;/th&gt;
        ///			&lt;th&gt;Today&apos;s NAV&lt;/th&gt;
        ///			&lt;th&gt;Note 2&lt;/th&gt;
        ///			&lt;th&gt;Change in NAV&lt;/th&gt;
        ///			&lt;th&gt;% Change in NAV&lt;/th&gt;
        ///		&lt;/tr&gt;
        ///		{% for currentFund in mutualFunds -%}
        ///		&lt;tr&gt;
        ///			&lt;td&gt;{{ cur [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Query_1_Default_Template {
            get {
                return ResourceManager.GetString("Query_1_Default_Template", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;html&gt;
        ///&lt;head&gt;
        ///	&lt;title&gt;&lt;/title&gt;
        ///&lt;/head&gt;
        ///&lt;body&gt;
        ///	&lt;h1&gt;Results for: {{fundCategory}}&lt;/h1&gt;
        ///	&lt;table border=1&gt;
        ///		&lt;tr&gt;
        ///			&lt;th&gt;Note 1&lt;/th&gt;
        ///			&lt;th&gt;Fund Name&lt;/th&gt;
        ///			&lt;th&gt;Value Research Rating as on Today&lt;/th&gt;
        ///			&lt;th&gt;Total Bond Sales in Rs (Crores) as on 3.30pm Today&lt;/th&gt;
        ///			&lt;th&gt;Fund Launch Date&lt;/th&gt;
        ///			&lt;th&gt;No. Of Days Since Launch&lt;/th&gt;
        ///			&lt;th&gt;Performance Score&lt;/th&gt;
        ///			&lt;th&gt;Performance Score Rank&lt;/th&gt;
        ///			&lt;th&gt;% Performance Improvement&lt;/th&gt;
        ///			&lt;th&gt;NAV as of today&lt;/th&gt;
        ///			&lt;th&gt;Note 2&lt;/th&gt;
        ///		&lt;/tr&gt;
        ///		{% fo [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Query_10_Default_Template {
            get {
                return ResourceManager.GetString("Query_10_Default_Template", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;html&gt;
        ///&lt;head&gt;
        ///	&lt;title&gt;&lt;/title&gt;
        ///&lt;/head&gt;
        ///&lt;body&gt;
        ///	&lt;h1&gt;Results for: {{fundCategory}}&lt;/h1&gt;
        ///	&lt;table border=1&gt;
        ///		&lt;tr&gt;
        ///			&lt;th&gt;Note 1&lt;/th&gt;
        ///			&lt;th&gt;Fund Name&lt;/th&gt;
        ///			&lt;th&gt;Value Research Rating as on Today&lt;/th&gt;
        ///			&lt;th&gt;Total Bond Sales in Rs (Crores) as on 3.30pm Today&lt;/th&gt;
        ///			&lt;th&gt;Fund Launch Date&lt;/th&gt;
        ///			&lt;th&gt;No. Of Days Since Launch&lt;/th&gt;
        ///			&lt;th&gt;Performance Score&lt;/th&gt;
        ///			&lt;th&gt;Performance Improvement % Rank&lt;/th&gt;
        ///			&lt;th&gt;% Performance Improvement&lt;/th&gt;
        ///			&lt;th&gt;NAV as of today&lt;/th&gt;
        ///			&lt;th&gt;Note 2&lt;/th&gt;
        ///		&lt;/tr&gt;        /// [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Query_11_Default_Template {
            get {
                return ResourceManager.GetString("Query_11_Default_Template", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;html&gt;
        ///&lt;head&gt;
        ///	&lt;title&gt;&lt;/title&gt;
        ///&lt;/head&gt;
        ///&lt;body&gt;
        ///	&lt;h1&gt;Results for: {{fundCategory}}&lt;/h1&gt;
        ///	&lt;table border=1&gt;
        ///		&lt;tr&gt;
        ///			&lt;th&gt;Note 1&lt;/th&gt;
        ///			&lt;th&gt;Fund Name&lt;/th&gt;
        ///			&lt;th&gt;Value Research Rating as on Today&lt;/th&gt;
        ///			&lt;th&gt;Total Bond Sales in Rs (Crores) as on 3.30pm Today&lt;/th&gt;
        ///			&lt;th&gt;Fund Launch Date&lt;/th&gt;
        ///			&lt;th&gt;No. Of Days Since Launch&lt;/th&gt;
        ///			
        ///			&lt;th&gt;Value Research Rating Rank&lt;/th&gt;
        ///			&lt;th&gt;NAV as of today&lt;/th&gt;
        ///			&lt;th&gt;Note 2&lt;/th&gt;
        ///		&lt;/tr&gt;
        ///		{% for currentFund in mutualFunds %}
        ///		&lt;tr&gt;
        ///			&lt;td&gt;{{currentFund [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Query_12_Default_Template {
            get {
                return ResourceManager.GetString("Query_12_Default_Template", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;html&gt;
        ///&lt;head&gt;
        ///	&lt;title&gt;&lt;/title&gt;
        ///&lt;/head&gt;
        ///&lt;body&gt;
        ///	&lt;h1&gt;Results for: {{fundCategory}}&lt;/h1&gt;
        ///	&lt;table border=1&gt;
        ///		&lt;tr&gt;
        ///			&lt;th&gt;Note 1&lt;/th&gt;
        ///			&lt;th&gt;Fund Name&lt;/th&gt;
        ///			&lt;th&gt;Value Research Rating as on Today&lt;/th&gt;
        ///			&lt;th&gt;Total Bond Sales in Rs (Crores) as on 3.30pm Today&lt;/th&gt;
        ///			&lt;th&gt;Fund Launch Date&lt;/th&gt;
        ///			&lt;th&gt;No. Of Days Since Launch&lt;/th&gt;
        ///			&lt;th&gt;NAV as of today&lt;/th&gt;
        ///			&lt;th&gt;Note 2&lt;/th&gt;
        ///		&lt;/tr&gt;
        ///		{% for currentFund in mutualFunds %}
        ///		&lt;tr&gt;
        ///			&lt;td&gt;{{currentFund.note1}}&lt;/td&gt;
        ///			&lt;td&gt;{{currentFund.fundName} [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Query_13_Default_Template {
            get {
                return ResourceManager.GetString("Query_13_Default_Template", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;html&gt;
        ///&lt;head&gt;
        ///	&lt;title&gt;&lt;/title&gt;
        ///&lt;/head&gt;
        ///&lt;body&gt;
        ///	&lt;h1&gt;Results for: {{fundCategory}}&lt;/h1&gt;
        ///	&lt;table border=1&gt;
        ///		&lt;tr&gt;
        ///			&lt;th&gt;Note 1&lt;/th&gt;
        ///			&lt;th&gt;Fund Name&lt;/th&gt;
        ///			&lt;th&gt;Value Research Rating as on Today&lt;/th&gt;
        ///			&lt;th&gt;Total Bond Sales in Rs (Crores) as on 3.30pm Today&lt;/th&gt;
        ///			&lt;th&gt;Fund Launch Date&lt;/th&gt;
        ///			&lt;th&gt;No. Of Days Since Launch&lt;/th&gt;
        ///			&lt;th&gt;Overall Score&lt;/th&gt;
        ///			&lt;th&gt;Performance Score Rank&lt;/th&gt;
        ///			&lt;th&gt;Performance Improvement % Rank&lt;/th&gt;
        ///			&lt;th&gt;Highest Rating Rank&lt;/th&gt;
        ///			&lt;th&gt;NAV as of today&lt;/th&gt;
        ///		 [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Query_14_Default_Template {
            get {
                return ResourceManager.GetString("Query_14_Default_Template", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;html&gt;
        ///&lt;head&gt;
        ///	&lt;title&gt;&lt;/title&gt;
        ///&lt;/head&gt;
        ///&lt;body&gt;
        ///	&lt;h1&gt;Results for: {{fundCategory}}&lt;/h1&gt;
        ///	&lt;table border=1&gt;
        ///		&lt;tr&gt;
        ///			&lt;th&gt;Note 1&lt;/th&gt;
        ///			&lt;th&gt;Fund Name&lt;/th&gt;
        ///			&lt;th&gt;Value Research Rating as on Today&lt;/th&gt;
        ///			&lt;th&gt;Total Bond Sales in Rs (Crores) as on 3.30pm Today&lt;/th&gt;
        ///			&lt;th&gt;Fund Launch Date&lt;/th&gt;
        ///			&lt;th&gt;No. Of Days Since Launch&lt;/th&gt;
        ///			
        ///			&lt;th&gt;Value Research Rating Rank&lt;/th&gt;
        ///			&lt;th&gt;NAV as of today&lt;/th&gt;
        ///			&lt;th&gt;Note 2&lt;/th&gt;
        ///		&lt;/tr&gt;
        ///		{% for currentFund in mutualFunds %}
        ///		&lt;tr&gt;
        ///			&lt;td&gt;{{currentFund [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Query_15_Default_Template {
            get {
                return ResourceManager.GetString("Query_15_Default_Template", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;html&gt;
        ///&lt;head&gt;
        ///	&lt;title&gt;&lt;/title&gt;
        ///&lt;/head&gt;
        ///&lt;body&gt;
        ///	&lt;h1&gt;Results for: {{fundCategory}}&lt;/h1&gt;
        ///	&lt;table border=1&gt;
        ///		&lt;tr&gt;
        ///			&lt;th&gt;Note 1&lt;/th&gt;
        ///			&lt;th&gt;Fund Name&lt;/th&gt;
        ///			&lt;th&gt;Value Research Rating as on Today&lt;/th&gt;
        ///			&lt;th&gt;Total Bond Sales in Rs (Crores) as on 3.30pm Today&lt;/th&gt;
        ///			&lt;th&gt;Fund Launch Date&lt;/th&gt;
        ///			&lt;th&gt;No. Of Days Since Launch&lt;/th&gt;
        ///			&lt;th&gt;NAV as of today&lt;/th&gt;
        ///			&lt;th&gt;Note 2&lt;/th&gt;
        ///		&lt;/tr&gt;
        ///		{% for currentFund in mutualFunds %}
        ///		&lt;tr&gt;
        ///			&lt;td&gt;{{currentFund.note1}}&lt;/td&gt;
        ///			&lt;td&gt;{{currentFund.fundName} [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Query_16_Default_Template {
            get {
                return ResourceManager.GetString("Query_16_Default_Template", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;html&gt;
        ///&lt;head&gt;
        ///	&lt;title&gt;&lt;/title&gt;
        ///&lt;/head&gt;
        ///&lt;body&gt;
        ///	&lt;h1&gt;Results for: {{fundCategory}}&lt;/h1&gt;
        ///	&lt;table border=1&gt;
        ///		&lt;tr&gt;
        ///			&lt;th&gt;Note 1&lt;/th&gt;
        ///			&lt;th&gt;Fund Name&lt;/th&gt;
        ///			&lt;th&gt;Value Research Rating as on Today&lt;/th&gt;
        ///			&lt;th&gt;Total Bond Sales in Rs (Crores) as on 3.30pm Today&lt;/th&gt;
        ///			&lt;th&gt;Fund Launch Date&lt;/th&gt;
        ///			&lt;th&gt;No. Of Days Since Launch&lt;/th&gt;
        ///			&lt;th&gt;Overall Score&lt;/th&gt;
        ///			&lt;th&gt;Performance Score Rank&lt;/th&gt;
        ///			&lt;th&gt;Performance Improvement % Rank&lt;/th&gt;
        ///			&lt;th&gt;Highest Rating Rank&lt;/th&gt;
        ///			&lt;th&gt;NAV as of today&lt;/th&gt;
        ///		 [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Query_17_Default_Template {
            get {
                return ResourceManager.GetString("Query_17_Default_Template", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;html&gt;
        ///&lt;head&gt;
        ///	&lt;title&gt;&lt;/title&gt;
        ///&lt;/head&gt;
        ///&lt;body&gt;
        ///	&lt;h1&gt;Results for: {{fundCategory}}&lt;/h1&gt;
        ///	&lt;table border=1&gt;
        ///		&lt;tr&gt;
        ///			&lt;th&gt;Note 1&lt;/th&gt;
        ///			&lt;th&gt;Fund Name&lt;/th&gt;
        ///			&lt;th&gt;Value Research Rating as on Today&lt;/th&gt;
        ///			&lt;th&gt;Total Bond Sales in Rs (Crores) as on 3.30pm Today&lt;/th&gt;
        ///			&lt;th&gt;Performance Score Rank&lt;/th&gt;
        ///			&lt;th&gt;Yesterday NAV&lt;/th&gt;
        ///			&lt;th&gt;Today&apos;s NAV&lt;/th&gt;
        ///			&lt;th&gt;Note 2&lt;/th&gt;
        ///			&lt;th&gt;Change in NAV&lt;/th&gt;
        ///			&lt;th&gt;% Change in NAV&lt;/th&gt;
        ///		&lt;/tr&gt;
        ///		{% for currentFund in mutualFunds %}
        ///		&lt;tr&gt;
        ///			&lt;td&gt;{{currentFu [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Query_18_Default_Template {
            get {
                return ResourceManager.GetString("Query_18_Default_Template", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;html&gt;
        ///&lt;head&gt;
        ///	&lt;title&gt;&lt;/title&gt;
        ///&lt;/head&gt;
        ///&lt;body&gt;
        ///	&lt;h1&gt;Results for: {{fundCategory}}&lt;/h1&gt;
        ///	&lt;table border=1&gt;
        ///		&lt;tr&gt;
        ///			&lt;th&gt;Note 1&lt;/th&gt;
        ///			&lt;th&gt;Fund Name&lt;/th&gt;
        ///			&lt;th&gt;Value Research Rating as on Today&lt;/th&gt;
        ///			&lt;th&gt;Total Bond Sales in Rs (Crores) as on 3.30pm Today&lt;/th&gt;
        ///			&lt;th&gt;Performance Score Rank&lt;/th&gt;
        ///			&lt;th&gt;Yesterday NAV&lt;/th&gt;
        ///			&lt;th&gt;Today&apos;s NAV&lt;/th&gt;
        ///			&lt;th&gt;Note 2&lt;/th&gt;
        ///			&lt;th&gt;Change in NAV&lt;/th&gt;
        ///			&lt;th&gt;% Change in NAV&lt;/th&gt;
        ///		&lt;/tr&gt;
        ///		{% for currentFund in mutualFunds %}
        ///		&lt;tr&gt;
        ///			&lt;td&gt;{{currentFu [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Query_19_Default_Template {
            get {
                return ResourceManager.GetString("Query_19_Default_Template", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;html&gt;
        ///&lt;head&gt;
        ///	&lt;title&gt;&lt;/title&gt;
        ///&lt;/head&gt;
        ///&lt;body&gt;
        ///	&lt;h1&gt;Results for: {{fundCategory}}&lt;/h1&gt;
        ///	&lt;table border=1&gt;
        ///		&lt;tr&gt;
        ///			&lt;th&gt;Note 1&lt;/th&gt;
        ///			&lt;th&gt;Fund Name&lt;/th&gt;
        ///			&lt;th&gt;Value Research Rating as on Today&lt;/th&gt;
        ///			&lt;th&gt;Total Bond Sales in Rs (Crores) as on 3.30pm Today&lt;/th&gt;
        ///			&lt;th&gt;Performance Score Rank&lt;/th&gt;
        ///			&lt;th&gt;Yesterday NAV&lt;/th&gt;
        ///			&lt;th&gt;Today&apos;s NAV&lt;/th&gt;
        ///			&lt;th&gt;Note 2&lt;/th&gt;
        ///			&lt;th&gt;Change in NAV&lt;/th&gt;
        ///			&lt;th&gt;% Change in NAV&lt;/th&gt;
        ///		&lt;/tr&gt;
        ///		{% for currentFund in mutualFunds %}
        ///		&lt;tr&gt;
        ///			&lt;td&gt;{{currentFu [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Query_2_Default_Template {
            get {
                return ResourceManager.GetString("Query_2_Default_Template", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;html&gt;
        ///&lt;head&gt;
        ///	&lt;title&gt;&lt;/title&gt;
        ///&lt;/head&gt;
        ///&lt;body&gt;
        ///	&lt;h1&gt;Results for: {{fundCategory}}&lt;/h1&gt;
        ///	&lt;table border=1&gt;
        ///		&lt;tr&gt;
        ///			&lt;th&gt;Note 1&lt;/th&gt;
        ///			&lt;th&gt;Fund Name&lt;/th&gt;
        ///			&lt;th&gt;Value Research Rating as on Today&lt;/th&gt;
        ///			&lt;th&gt;Total Bond Sales in Rs (Crores) as on 3.30pm Today&lt;/th&gt;
        ///			&lt;th&gt;Fund Launch Date&lt;/th&gt;
        ///			&lt;th&gt;No. Of Days Since Launch&lt;/th&gt;
        ///			&lt;th&gt;Performance Score&lt;/th&gt;
        ///			&lt;th&gt;Performance Score Rank&lt;/th&gt;
        ///			&lt;th&gt;% Performance Improvement&lt;/th&gt;
        ///			&lt;th&gt;NAV as of today&lt;/th&gt;
        ///			&lt;th&gt;Note 2&lt;/th&gt;
        ///		&lt;/tr&gt;
        ///		{% fo [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Query_20_Default_Template {
            get {
                return ResourceManager.GetString("Query_20_Default_Template", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;html&gt;
        ///&lt;head&gt;
        ///	&lt;title&gt;&lt;/title&gt;
        ///&lt;/head&gt;
        ///&lt;body&gt;
        ///	&lt;h1&gt;Results for: {{fundCategory}}&lt;/h1&gt;
        ///	&lt;table border=1&gt;
        ///		&lt;tr&gt;
        ///			&lt;th&gt;Note 1&lt;/th&gt;
        ///			&lt;th&gt;Fund Name&lt;/th&gt;
        ///			&lt;th&gt;Value Research Rating as on Today&lt;/th&gt;
        ///			&lt;th&gt;Total Bond Sales in Rs (Crores) as on 3.30pm Today&lt;/th&gt;
        ///			&lt;th&gt;Fund Launch Date&lt;/th&gt;
        ///			&lt;th&gt;No. Of Days Since Launch&lt;/th&gt;
        ///			&lt;th&gt;Performance Score&lt;/th&gt;
        ///			&lt;th&gt;Performance Score Rank&lt;/th&gt;
        ///			&lt;th&gt;% Performance Improvement&lt;/th&gt;
        ///			&lt;th&gt;NAV as of today&lt;/th&gt;
        ///			&lt;th&gt;Note 2&lt;/th&gt;
        ///		&lt;/tr&gt;
        ///		{% fo [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Query_3_Default_Template {
            get {
                return ResourceManager.GetString("Query_3_Default_Template", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;html&gt;
        ///&lt;head&gt;
        ///	&lt;title&gt;&lt;/title&gt;
        ///&lt;/head&gt;
        ///&lt;body&gt;
        ///	&lt;h1&gt;Results for: {{fundCategory}}&lt;/h1&gt;
        ///	&lt;table border=1&gt;
        ///		&lt;tr&gt;
        ///			&lt;th&gt;Note 1&lt;/th&gt;
        ///			&lt;th&gt;Fund Name&lt;/th&gt;
        ///			&lt;th&gt;Value Research Rating as on Today&lt;/th&gt;
        ///			&lt;th&gt;Total Bond Sales in Rs (Crores) as on 3.30pm Today&lt;/th&gt;
        ///			&lt;th&gt;Fund Launch Date&lt;/th&gt;
        ///			&lt;th&gt;No. Of Days Since Launch&lt;/th&gt;
        ///			&lt;th&gt;Performance Score&lt;/th&gt;
        ///			&lt;th&gt;Performance Improvement % Rank&lt;/th&gt;
        ///			&lt;th&gt;% Performance Improvement&lt;/th&gt;
        ///			&lt;th&gt;NAV as of today&lt;/th&gt;
        ///			&lt;th&gt;Note 2&lt;/th&gt;
        ///		&lt;/tr&gt;        /// [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Query_4_Default_Template {
            get {
                return ResourceManager.GetString("Query_4_Default_Template", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;html&gt;
        ///&lt;head&gt;
        ///	&lt;title&gt;&lt;/title&gt;
        ///&lt;/head&gt;
        ///&lt;body&gt;
        ///	&lt;h1&gt;Results for: {{fundCategory}}&lt;/h1&gt;
        ///	&lt;table border=1&gt;
        ///		&lt;tr&gt;
        ///			&lt;th&gt;Note 1&lt;/th&gt;
        ///			&lt;th&gt;Fund Name&lt;/th&gt;
        ///			&lt;th&gt;Value Research Rating as on Today&lt;/th&gt;
        ///			&lt;th&gt;Total Bond Sales in Rs (Crores) as on 3.30pm Today&lt;/th&gt;
        ///			&lt;th&gt;Fund Launch Date&lt;/th&gt;
        ///			&lt;th&gt;No. Of Days Since Launch&lt;/th&gt;
        ///			
        ///			&lt;th&gt;Value Research Rating Rank&lt;/th&gt;
        ///			&lt;th&gt;NAV as of today&lt;/th&gt;
        ///			&lt;th&gt;Note 2&lt;/th&gt;
        ///		&lt;/tr&gt;
        ///		{% for currentFund in mutualFunds %}
        ///		&lt;tr&gt;
        ///			&lt;td&gt;{{currentFund [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Query_5_Default_Template {
            get {
                return ResourceManager.GetString("Query_5_Default_Template", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;html&gt;
        ///&lt;head&gt;
        ///	&lt;title&gt;&lt;/title&gt;
        ///&lt;/head&gt;
        ///&lt;body&gt;
        ///	&lt;h1&gt;Results for: {{fundCategory}}&lt;/h1&gt;
        ///	&lt;table border=1&gt;
        ///		&lt;tr&gt;
        ///			&lt;th&gt;Note 1&lt;/th&gt;
        ///			&lt;th&gt;Fund Name&lt;/th&gt;
        ///			&lt;th&gt;Value Research Rating as on Today&lt;/th&gt;
        ///			&lt;th&gt;Total Bond Sales in Rs (Crores) as on 3.30pm Today&lt;/th&gt;
        ///			&lt;th&gt;Fund Launch Date&lt;/th&gt;
        ///			&lt;th&gt;No. Of Days Since Launch&lt;/th&gt;
        ///			&lt;th&gt;NAV as of today&lt;/th&gt;
        ///			&lt;th&gt;Note 2&lt;/th&gt;
        ///		&lt;/tr&gt;
        ///		{% for currentFund in mutualFunds %}
        ///		&lt;tr&gt;
        ///			&lt;td&gt;{{currentFund.note1}}&lt;/td&gt;
        ///			&lt;td&gt;{{currentFund.fundName} [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Query_6_Default_Template {
            get {
                return ResourceManager.GetString("Query_6_Default_Template", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;html&gt;
        ///&lt;head&gt;
        ///	&lt;title&gt;&lt;/title&gt;
        ///&lt;/head&gt;
        ///&lt;body&gt;
        ///	&lt;h1&gt;Results for: {{fundCategory}}&lt;/h1&gt;
        ///	&lt;table border=1&gt;
        ///		&lt;tr&gt;
        ///			&lt;th&gt;Note 1&lt;/th&gt;
        ///			&lt;th&gt;Fund Name&lt;/th&gt;
        ///			&lt;th&gt;Value Research Rating as on Today&lt;/th&gt;
        ///			&lt;th&gt;Total Bond Sales in Rs (Crores) as on 3.30pm Today&lt;/th&gt;
        ///			&lt;th&gt;Fund Launch Date&lt;/th&gt;
        ///			&lt;th&gt;No. Of Days Since Launch&lt;/th&gt;
        ///			&lt;th&gt;Overall Score&lt;/th&gt;
        ///			&lt;th&gt;Performance Score Rank&lt;/th&gt;
        ///			&lt;th&gt;Performance Improvement % Rank&lt;/th&gt;
        ///			&lt;th&gt;Highest Rating Rank&lt;/th&gt;
        ///			&lt;th&gt;NAV as of today&lt;/th&gt;
        ///		 [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Query_7_Default_Template {
            get {
                return ResourceManager.GetString("Query_7_Default_Template", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;html&gt;
        ///&lt;head&gt;
        ///	&lt;title&gt;&lt;/title&gt;
        ///&lt;/head&gt;
        ///&lt;body&gt;
        ///	&lt;h1&gt;Results for: {{fundCategory}}&lt;/h1&gt;
        ///	&lt;table border=1&gt;
        ///		&lt;tr&gt;
        ///			&lt;th&gt;Note 1&lt;/th&gt;
        ///			&lt;th&gt;Fund Name&lt;/th&gt;
        ///			&lt;th&gt;Value Research Rating as on Today&lt;/th&gt;
        ///			&lt;th&gt;Total Bond Sales in Rs (Crores) as on 3.30pm Today&lt;/th&gt;
        ///			&lt;th&gt;Performance Score Rank&lt;/th&gt;
        ///			&lt;th&gt;Yesterday NAV&lt;/th&gt;
        ///			&lt;th&gt;Today&apos;s NAV&lt;/th&gt;
        ///			&lt;th&gt;Note 2&lt;/th&gt;
        ///			&lt;th&gt;Change in NAV&lt;/th&gt;
        ///			&lt;th&gt;% Change in NAV&lt;/th&gt;
        ///		&lt;/tr&gt;
        ///		{% for currentFund in mutualFunds %}
        ///		&lt;tr&gt;
        ///			&lt;td&gt;{{currentFu [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Query_8_Default_Template {
            get {
                return ResourceManager.GetString("Query_8_Default_Template", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;html&gt;
        ///&lt;head&gt;
        ///	&lt;title&gt;&lt;/title&gt;
        ///&lt;/head&gt;
        ///&lt;body&gt;
        ///	&lt;h1&gt;Results for: {{fundCategory}}&lt;/h1&gt;
        ///	&lt;table border=1&gt;
        ///		&lt;tr&gt;
        ///			&lt;th&gt;Note 1&lt;/th&gt;
        ///			&lt;th&gt;Fund Name&lt;/th&gt;
        ///			&lt;th&gt;Value Research Rating as on Today&lt;/th&gt;
        ///			&lt;th&gt;Total Bond Sales in Rs (Crores) as on 3.30pm Today&lt;/th&gt;
        ///			&lt;th&gt;Performance Score Rank&lt;/th&gt;
        ///			&lt;th&gt;Yesterday NAV&lt;/th&gt;
        ///			&lt;th&gt;Today&apos;s NAV&lt;/th&gt;
        ///			&lt;th&gt;Note 2&lt;/th&gt;
        ///			&lt;th&gt;Change in NAV&lt;/th&gt;
        ///			&lt;th&gt;% Change in NAV&lt;/th&gt;
        ///		&lt;/tr&gt;
        ///		{% for currentFund in mutualFunds %}
        ///		&lt;tr&gt;
        ///			&lt;td&gt;{{currentFu [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Query_9_Default_Template {
            get {
                return ResourceManager.GetString("Query_9_Default_Template", resourceCulture);
            }
        }
    }
}

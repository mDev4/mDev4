﻿

#pragma checksum "C:\Users\lars\Documents\Git\mDev4\KVS\KVS_windows\HomePage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "B4063E7B05A39BDB8F7BFD78D23FD8CE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KVS_windows
{
    partial class HomePage : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 44 "..\..\HomePage.xaml"
                ((global::Windows.UI.Xaml.Controls.TextBlock)(target)).SelectionChanged += this.messageT_Copy1_SelectionChanged;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 20 "..\..\HomePage.xaml"
                ((global::Windows.UI.Xaml.Controls.TextBlock)(target)).SelectionChanged += this.menuClassTextBlock_SelectionChanged;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}



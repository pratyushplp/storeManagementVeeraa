﻿#pragma checksum "..\..\..\Views\TransactionView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "DAB321E215FDAAFBA804968EEEE24C79E62DEEE7"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using LoginUI.Views;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace LoginUI.Views {
    
    
    /// <summary>
    /// TransactionView
    /// </summary>
    public partial class TransactionView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 36 "..\..\..\Views\TransactionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker datePicker;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\Views\TransactionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtProductCode;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\Views\TransactionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtInventoryQty;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\Views\TransactionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtProductType;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\Views\TransactionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPrice;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\Views\TransactionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtQty;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\Views\TransactionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBillNo;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\Views\TransactionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox checkBill;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\Views\TransactionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSubTotal;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\Views\TransactionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtDiscount;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\..\Views\TransactionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtVAT;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\..\Views\TransactionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtTotalAmount;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\..\Views\TransactionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPaidAmount;
        
        #line default
        #line hidden
        
        
        #line 119 "..\..\..\Views\TransactionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtReturnAmount;
        
        #line default
        #line hidden
        
        
        #line 128 "..\..\..\Views\TransactionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton CashPayment;
        
        #line default
        #line hidden
        
        
        #line 129 "..\..\..\Views\TransactionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton CreditPayment;
        
        #line default
        #line hidden
        
        
        #line 130 "..\..\..\Views\TransactionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton CCPayment;
        
        #line default
        #line hidden
        
        
        #line 131 "..\..\..\Views\TransactionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbBank;
        
        #line default
        #line hidden
        
        
        #line 141 "..\..\..\Views\TransactionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSave;
        
        #line default
        #line hidden
        
        
        #line 146 "..\..\..\Views\TransactionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgTransaction;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/LoginUI;component/views/transactionview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\TransactionView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 10 "..\..\..\Views\TransactionView.xaml"
            ((LoginUI.Views.TransactionView)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.datePicker = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 3:
            this.txtProductCode = ((System.Windows.Controls.TextBox)(target));
            
            #line 45 "..\..\..\Views\TransactionView.xaml"
            this.txtProductCode.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TxtProductCode_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txtInventoryQty = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txtProductType = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.txtPrice = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.txtQty = ((System.Windows.Controls.TextBox)(target));
            
            #line 53 "..\..\..\Views\TransactionView.xaml"
            this.txtQty.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.TxtQty_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 55 "..\..\..\Views\TransactionView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.addButton_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.txtBillNo = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.checkBill = ((System.Windows.Controls.CheckBox)(target));
            
            #line 70 "..\..\..\Views\TransactionView.xaml"
            this.checkBill.Checked += new System.Windows.RoutedEventHandler(this.CheckBill_Checked);
            
            #line default
            #line hidden
            
            #line 70 "..\..\..\Views\TransactionView.xaml"
            this.checkBill.Unchecked += new System.Windows.RoutedEventHandler(this.CheckBill_Unchecked);
            
            #line default
            #line hidden
            return;
            case 11:
            this.txtSubTotal = ((System.Windows.Controls.TextBox)(target));
            
            #line 81 "..\..\..\Views\TransactionView.xaml"
            this.txtSubTotal.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtSubTotal_TextChanged);
            
            #line default
            #line hidden
            return;
            case 12:
            this.txtDiscount = ((System.Windows.Controls.TextBox)(target));
            
            #line 88 "..\..\..\Views\TransactionView.xaml"
            this.txtDiscount.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.TxtDiscount_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 88 "..\..\..\Views\TransactionView.xaml"
            this.txtDiscount.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtDiscount_TextChanged);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 89 "..\..\..\Views\TransactionView.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Checked += new System.Windows.RoutedEventHandler(this.Discount_CheckBox_Checked);
            
            #line default
            #line hidden
            
            #line 89 "..\..\..\Views\TransactionView.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Unchecked += new System.Windows.RoutedEventHandler(this.Discount_CheckBox_UnChecked);
            
            #line default
            #line hidden
            return;
            case 14:
            this.txtVAT = ((System.Windows.Controls.TextBox)(target));
            
            #line 97 "..\..\..\Views\TransactionView.xaml"
            this.txtVAT.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.TxtVAT_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 97 "..\..\..\Views\TransactionView.xaml"
            this.txtVAT.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TxtVAT_TextChanged);
            
            #line default
            #line hidden
            return;
            case 15:
            this.txtTotalAmount = ((System.Windows.Controls.TextBox)(target));
            return;
            case 16:
            this.txtPaidAmount = ((System.Windows.Controls.TextBox)(target));
            
            #line 111 "..\..\..\Views\TransactionView.xaml"
            this.txtPaidAmount.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.TxtPaidAmount_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 111 "..\..\..\Views\TransactionView.xaml"
            this.txtPaidAmount.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TxtPaidAmount_TextChanged);
            
            #line default
            #line hidden
            return;
            case 17:
            this.txtReturnAmount = ((System.Windows.Controls.TextBox)(target));
            return;
            case 18:
            this.CashPayment = ((System.Windows.Controls.RadioButton)(target));
            
            #line 128 "..\..\..\Views\TransactionView.xaml"
            this.CashPayment.Click += new System.Windows.RoutedEventHandler(this.CashPayment_Click);
            
            #line default
            #line hidden
            return;
            case 19:
            this.CreditPayment = ((System.Windows.Controls.RadioButton)(target));
            
            #line 129 "..\..\..\Views\TransactionView.xaml"
            this.CreditPayment.Click += new System.Windows.RoutedEventHandler(this.CreditPayment_Click);
            
            #line default
            #line hidden
            return;
            case 20:
            this.CCPayment = ((System.Windows.Controls.RadioButton)(target));
            
            #line 130 "..\..\..\Views\TransactionView.xaml"
            this.CCPayment.Click += new System.Windows.RoutedEventHandler(this.CCPayment_Click);
            
            #line default
            #line hidden
            return;
            case 21:
            this.cmbBank = ((System.Windows.Controls.ComboBox)(target));
            
            #line 131 "..\..\..\Views\TransactionView.xaml"
            this.cmbBank.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cmbBank_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 22:
            this.btnSave = ((System.Windows.Controls.Button)(target));
            
            #line 141 "..\..\..\Views\TransactionView.xaml"
            this.btnSave.Click += new System.Windows.RoutedEventHandler(this.btnSave_Button_Click);
            
            #line default
            #line hidden
            return;
            case 23:
            this.dgTransaction = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}


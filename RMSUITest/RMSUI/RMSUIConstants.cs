using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RMSUI
{
    public static class RMSUIConstants
    {
        public  enum ItemType
        {
            SeatedButNoOrdered,
            Ordered,
            WaitingForPayment,
            BarService,
            Collection,
            Waiting,
            Delevery
        };
        public enum FunctionType
        {
            Normal,
            NormalCenter,
            Back,
            Refresh,
            Add,
            Remove,
            Next,
            Previous,
            Print,
            View,
            Option,
            Control,
            Logoff
        };

        public enum FunctionalIcon
        {
            Add,
            Back,
            Control,
            Next,
            Option,
            Privious,
            Print,
            Reload,
            Remove,
            TableOrdred,
            TableSeated,
            TableWaitingCollection,
            TableWaitingForPayment,
            TableWaitingWaiting,
            TakewayBarservice,
            TakewayDelevery,
            SystemSettings,
            Close,
            OrderDetailsChange,
            CheckOrder,
            ItemDetials,
            KichenText,
            Modify,
            OrderLog,
            Plu,
            PrintGuestBill,
            PromotionDiscount,
            ItemQuantity,
            ProcessingItemIcon,
            KichenTextIcon,
            WebAdminIcon,
            UserSettingsIcon,
            MouseSettingsIcon,
            GeneralSettingsIcon,
            RMSAdminIcon,
            BarSettingsIcon,
            VoidItemSettingsIcon,
            kichenSettingsIcon,
            LogRegisterIcon,
            SpecialModifyIcon,
            INVReportIcon,
            PrinterSettingsIcon,
            EFTIcon,
            None
        }

        public enum FunctionalBtnBackground
        {
            RedSlightMouseUp,
            RedSlightMouseDown,
            GreenLightMouseUp,
            GreenLightMouseDown,
            CynLightGreenMouseUp,
            CynLightGreenMouseDown,
            YellowMouseUp,
            YellowMouseDown,
            CynLightMouseUp,
            CynLightMouseDown,
            SkyBlueMouseUp,
            SkyBlueMouseDown,
            KeyBordMouseUP,
            KeyBordMouseDown,
            YellowBigMouseUp,
            YellowBigMouseDown,
            BlueBigMouseUp,
            BlueBigMouseDown,
            GreenBigMouseUp,
            GreenBigMouseDown,
            CynBlueBigMouseUp,
            CynBlueBigMouseDown,
            YellowLightBigMouseUp,
            YellowLightBigMouseDown,
            WhiteBigMouseUp,
            WhiteBigMouseDown,
            AlphaBigMouseUp,
            AlphaBigMouseDown,
            None
        }
        

    }
}

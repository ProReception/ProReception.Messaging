namespace ProReception.Messaging.Messages
{
    using System;
    using System.Collections.Generic;

    public class VisitorArrivalMessage
    {
        public string HostName { get; set; }

        public string HostSkypeId { get; set; }

        public string HostLyncUri { get; set; }

        public string VisitorName { get; set; }

        public string VisitorCompany { get; set; }

        public string CardNumber { get; set; }

        public DateTime CheckinTime { get; set; }

        public string SkypeMessage { get; set; }

        public string LyncMessage { get; set; }

        public IList<VisitorArrivalAction> Actions { get; set; }

        public bool KeepImWindowsOpen { get; set; }

        public PrinterType PrinterType { get; set; }

        public bool EnablePrinterCutter { get; set; }

        public string WifiSsid { get; set; }

        public string WifiPassword { get; set; }
    }
}

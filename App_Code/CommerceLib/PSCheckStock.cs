namespace CommerceLib
{
    /// <summary>
    /// 3rd pipeline stage – used to send a notification email to
    /// the supplier, asking whether goods are available
    /// </summary>
    public class PSCheckStock : IPipelineSection
    {
        private OrderProcessor orderProcessor;

        public void Process(OrderProcessor processor)
        {
            // set processor reference
            orderProcessor = processor;
            // audit
            orderProcessor.KrijoAudit("PSCheckStock started.", 20200);

            try
            {
                // send mail to supplier
                orderProcessor.MailSupplier("BalloonShop stock check.",
                  GetMailBody());

                // audit
                orderProcessor.KrijoAudit(
                  "Notification e-mail sent to supplier.", 20202);
                // update order status
                orderProcessor.Order.UpdateStatus(3);
            }
            catch
            {
                // mail sending failure
                throw new OrderProcessorException(
                  "Unable to send e-mail to supplier.", 2);
            }
            // audit
            processor.KrijoAudit("PSCheckStock finished.", 20201);
        }

        private string GetMailBody()
        {
            // construct message body
            string mail =
              "The following goods have been ordered:\n\n"
              + orderProcessor.Order.OrderAsString
              + "\n\nPlease check availability and confirm via "
              + "http://localhost:1041/dengu/AdminOrders.aspx"
              + "\n\nOrder reference number:\n\n"
              + orderProcessor.Order.OrderID.ToString();
            return mail;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommerceLib
{
    /// <summary>
    /// 2nd pipeline stage - used to check that the customer
    /// has the required funds available for purchase
    /// </summary>
    public class PSCheckFunds : IPipelineSection
    {
        private OrderProcessor orderProcessor;

        public void Process(OrderProcessor processor)
        {
            // set processor reference
            orderProcessor = processor;
            // audit
            orderProcessor.KrijoAudit("PSCheckFunds started.", 20100);

            try
            {
                // check customer funds
                // assume they exist for now
                // set order authorization code and reference
                orderProcessor.Order.SetAuthCodeAndReference("AuthCode",
                  "Reference");

                // audit
                orderProcessor.KrijoAudit("Funds available for purchase.",
                  20102);
                // update order status
                orderProcessor.Order.UpdateStatus(2);
                // continue processing
                orderProcessor.ContinueNow = true;
            }

            catch
            {
                // fund checking failure
                throw new OrderProcessorException(
                  "Error occured while checking funds.", 1);
            }
            // audit
            processor.KrijoAudit("PSCheckFunds finished.", 20101);
        }
    }
}

﻿namespace CompanyName.MyMeetings.API.Modules.Payments.Subscriptions;

public class BuySubscriptionRequest
{
    public string SubscriptionTypeCode { get; set; }

    public string CountryCode { get; set; }

    public decimal Value { get; set; }

    public string Currency { get; set; }
}
namespace Mst.SharedKernel.Statics
{
    public static class ResultErrorCodes
    {
        public const string InternalError = "InternalError";
        public const string Ok = "Ok";
        public const string NotFound = "NotFound";
        public const string Forbidden = "Forbidden";
        public const string Conflicted = "Conflicted";
        public const string Invalid = "Invalid";
        public const string Unauthorized = "Unauthorized";

        #region HttpResponse

        public const string ResponseInvalid = "RESPONSE_INVALID";

        public const string CompanyUidRequired = "COMPANY_ID_REQUIRED";

        public const string ResponseDeserializationFailed = "RESPONSE_DESERIALIZATION_FAILED";

        #endregion

        #region CustomerReview
        public const string CustomerReviewNotFound = "CUSTOMER_REVIEW_NOT_FOUND";
        public const string CustomerReviewAlreadyExists = "CUSTOMER_REVIEW_ALREADY_EXISTS";
        public const string CustomerReviewInvalid = "CUSTOMER_REVIEW_INVALID";

        public const string CustomerReviewRatingInvalid = "CUSTOMER_REVIEW_RATING_INVALID";

        public const string CustomerReviewRequiredReviewText = "CUSTOMER_REVIEW_REQUIRED_REVIEW_TEXT";
        public const string CustomerReviewRequiredCustomerName = "CUSTOMER_REVIEW_REQUIRED_CUSTOMER_NAME";

        #endregion
    }
}
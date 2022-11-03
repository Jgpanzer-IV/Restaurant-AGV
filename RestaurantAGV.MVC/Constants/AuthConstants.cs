namespace RestaurantAGV.MVC.Constants;

public static class AuthConstants{

    public static readonly string DefaultScheme = "Cookies";
    public static readonly string CookieScheme = "Cookies";
    public static readonly string Cookie = "Cookie";
    public static readonly string AdminPolicy = "AdminPolicy";
    public static readonly string CustomerPolicy = "CustomerPolicy";
    
    
}

public static class ClaimConstants{
    public static readonly string ClaimRole = "roles";
    public static readonly string CustomerClaimId = "customer-id";
    public static readonly string TableClaimId = "table-id";
    public static readonly string BasketClaimId = "basket-id";
    public static readonly string BillClaimId = "bill-id";
    public static readonly string AdminClaimId = "admin-id";
}


public static class RoleConst{
    public static readonly string AdminRole = "admin";
    public static readonly string StuffRole = "stuff";
    public static readonly string CustomerRole = "customer";
}
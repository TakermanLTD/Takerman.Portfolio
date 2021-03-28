﻿using Cofoundry.Domain;

namespace Takerman.Portfolio.Web.Domain
{
    /// <summary>
    /// Defining a user area allows us to require users to
    /// sign-up or log in to access certain features of the site.
    ///
    /// For more info see https://www.cofoundry.org/docs/content-management/user-areas
    /// </summary>
    public class MemberUserArea : IUserAreaDefinition
    {
        /// <summary>
        /// Static access to the area code to make querying
        /// easier
        /// </summary>
        public const string MemberUserAreaCode = "SPA";

        /// <summary>
        /// Indicates if users in this area can login using a password. If this is false
        /// the password field will be null and login will typically be via SSO or some
        /// other method.
        /// </summary>
        public bool AllowPasswordLogin => true;

        /// <summary>
        /// Display name of the area, used in the Cofoundry admin panel
        /// as the navigation link to manage your users. This should be singular
        /// because "Users" is appended to the link text.
        /// </summary>
        public string Name => "SPA Cat";

        /// <summary>
        /// Indicates whether the user should login using thier email address as the username.
        /// Some SSO systems might provide only a username and not an email address so in
        /// this case the email address is allowed to be null.
        /// </summary>
        public bool UseEmailAsUsername => true;

        /// <summary>
        /// A unique 3 letter code identifying this user area. The cofoundry
        /// user are uses the code "COF" so you can pick anything else!
        /// </summary>
        public string UserAreaCode => MemberUserAreaCode;

        /// <summary>
        /// Because the login routing is handled by the front end framework, we don't need to redirect to
        /// a specific login route.
        /// </summary>
        public string LoginPath => "/";

        /// <summary>
        /// Setting this to true means that this user area will be used as the default login
        /// schema which means the HttpContext.User property will be set to this identity.
        /// </summary>
        public bool IsDefaultAuthSchema => true;
    }
}
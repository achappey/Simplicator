namespace Simplicator.Models
{
    /// <summary>
    /// Represents a user with access to the Simplicator API.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="User"/> class with the specified environment, key, and secret.
    /// </remarks>
    /// <param name="environment">The user's environment.</param>
    /// <param name="key">The user's API key.</param>
    /// <param name="secret">The user's API secret.</param>
    public class User(string environment, string key, string secret)
    {
        /// <summary>
        /// Gets or sets the environment of the user.
        /// </summary>
        public string Environment { get; set; } = environment;

        /// <summary>
        /// Gets or sets the API key of the user.
        /// </summary>
        public string Key { get; set; } = key;

        /// <summary>
        /// Gets or sets the API secret of the user.
        /// </summary>
        public string Secret { get; set; } = secret;
    }
}

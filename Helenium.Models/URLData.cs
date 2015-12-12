using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using R = Helenium.Resources.Resources;

namespace Helenium.Models
{
    /// <summary>
    /// URLData model
    /// </summary>
    public class URLData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="URLData" /> class.
        /// </summary>
        public URLData()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="URLData" /> class.
        /// </summary>
        /// <param name="URL">The URL.</param>
        /// <param name="visited">if set to <c>true</c> [visited].</param>
        /// <param name="level">The level.</param>
        public URLData(string URL, bool visited, int level)
        {
//            this.Parent = parent;
            this.URL = URL;
            this.Visited = visited;
            this.Level = level;
        }
        /// <summary>
        /// Gets or sets the level of reference to base url.
        /// </summary>
        /// <value>
        /// The level.
        /// </value>
        public int Level { get; set; }
        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        public string URL { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [visited].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [visited]; otherwise, <c>false</c>.
        /// </value>
        public bool Visited { get; set; }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return this.URL + ", "+R.Visited+": " + (this.Visited ? R.Yes : R.No) + ", "+R.Level+": " + Level;
        }
    }
}

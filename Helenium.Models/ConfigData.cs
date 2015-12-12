using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.IO;
using System.Linq;
using System.Text;

namespace Helenium.Models
{
    /// <summary>
    /// ConfigData model
    /// </summary>
    public class ConfigData
    {
        /// <summary>
        /// The HTML
        /// </summary>
        private StringBuilder html;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigData"/> class.
        /// </summary>
        public ConfigData()
        {
            html = new StringBuilder();
            Urls = new List<URLData>();
        }

        /// <summary>
        /// Gets or sets the urls.
        /// </summary>
        /// <value>
        /// The urls.
        /// </value>
        [NotMapped]
        public List<URLData> Urls { get; set; }

        /// <summary>
        /// Gets or sets the urls serialized.
        /// </summary>
        /// <value>
        /// The urls serialized.
        /// </value>
        public string UrlsSerialized { 
            get
            {
                var sb = new StringBuilder();
                lock (Urls)
                {
                    foreach (var url in Urls.ToList())
                    {
                        if (sb.Length != 0)
                            sb.Append('\n');
                        sb.AppendFormat("{0}{1:00000}{2}\n", url.Visited ? '1' : '0', url.Level, url.URL);
                    }
                }
                return sb.ToString();
            }
            set
            {
                var data = value.Split('\n');

                lock (Urls)
                {
                    Urls.Clear();
                    foreach (var item in data)
                    {
                        if (!string.IsNullOrEmpty(item))
                            Urls.Add(new URLData() { Visited = (item[0] == '1'), Level = int.Parse(item.Substring(1,5)), URL = item.Substring(6) });
                    }
                }
            }
        }

        /// <summary>
        /// Adds the URL.
        /// </summary>
        /// <param name="URL">The URL.</param>
        /// <param name="Visited">if set to <c>true</c> [visited].</param>
        /// <param name="level">The level.</param>
        public void AddUrl(string URL, bool Visited, int level)
        {
            URLData item = new URLData(URL, Visited, level);
            AddUrl(item);
        }

        /// <summary>
        /// Adds the URL.
        /// </summary>
        /// <param name="item">The item.</param>
        public void AddUrl(URLData item)
        {
            lock (Urls)
            {
                Urls.Add(item);
            }
            HasChanged = true;
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [is runnning].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is runnning]; otherwise, <c>false</c>.
        /// </value>
        [NotMapped]
        public bool IsRunnning { get; set; }
        /// <summary>
        /// Gets or sets the delay ms.
        /// </summary>
        /// <value>
        /// The delay ms.
        /// </value>
        public int DelayMs { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [has changed].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [has changed]; otherwise, <c>false</c>.
        /// </value>
        [NotMapped]
        public bool HasChanged { get; set; }
        /// <summary>
        /// Gets or sets the log path.
        /// </summary>
        /// <value>
        /// The log path.
        /// </value>
        public string LogPath { get; set; }
        /// <summary>
        /// Gets or sets the maximum length of the HTML.
        /// </summary>
        /// <value>
        /// The maximum length of the HTML.
        /// </value>
        public int MaxHtmlLength { get; set; }
        /// <summary>
        /// Gets or sets the maximum level.
        /// </summary>
        /// <value>
        /// The maximum level.
        /// </value>
        public int MaxLevel { get; set; }
        /// <summary>
        /// Gets or sets the errors.
        /// </summary>
        /// <value>
        /// The errors.
        /// </value>
        public ICollection<ErrorData> Errors { get; set; }

        /// <summary>
        /// The n
        /// </summary>
        static int n = 1;

        /// <summary>
        /// Appends the log.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <param name="forceSave">if set to <c>true</c> [force save].</param>
        public void AppendLog(string s, bool forceSave = false)
        {
            s = string.Format("<p>{0:yyyyMMdd-HHmmss}<br/>{1}</p>", DateTime.UtcNow, s);
            html.AppendLine(s);
            if (html.Length > 0 && (html.Length > MaxHtmlLength || forceSave))
            {
                string path = string.Format("{0}\\{1:yyyyMMdd}-{2}.htm", LogPath, DateTime.Now, n);
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.Write(html);
                }
                if (html.Length > MaxHtmlLength)
                {
                    html.Clear();
                    n++;
                }
            }
            HasChanged = true;
        }
        /// <summary>
        /// Gets the log.
        /// </summary>
        /// <returns></returns>
        public string GetLog()
        {
            HasChanged = false;
            return html.ToString();
        }

        /// <summary>
        /// Clears this instance.
        /// </summary>
        public void Clear()
        {
            AppendLog("Test data is reset", true);
            html.Clear();
            Urls.Clear();
        }

        /// <summary>
        /// Gets or sets the URL pattern.
        /// </summary>
        /// <value>
        /// The URL pattern.
        /// </value>
        public string UrlPattern { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is debugger].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is debugger]; otherwise, <c>false</c>.
        /// </value>
        public bool IsDebugger { get; set; }
    }
}

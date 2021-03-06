// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.HDInsight.Job.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Parameters specifying the HDInsight MapReduce job definition.
    /// </summary>
    public partial class MapReduceJobSubmissionParameters
    {
        /// <summary>
        /// Optional. Gets the arguments for the jobDetails.
        /// </summary>
        public IList<string> Arguments { get; set; }

        /// <summary>
        /// Optional. Gets or sets define parameter list.
        /// </summary>
        public IDictionary<string, string> Defines { get; set; }
        
        /// <summary>
        /// Optional. List of files to be copied to the cluster.
        /// </summary>
        public IList<string> Files { get; set; }
        
        /// <summary>
        /// Optional. Gets or sets the class.
        /// </summary>
        public string JarClass { get; set; }
        
        /// <summary>
        /// Optional. Gets or sets the Jar file.
        /// </summary>
        public string JarFile { get; set; }

        /// <summary>
        /// Optional. List of files to include in the classpath.
        /// </summary>
        public IList<string> LibJars { get; set; }
        
        /// <summary>
        /// Optional. Status directory in the default storage account to store job files stderr, stdout and exit.
        /// </summary>
        public string StatusDir { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the MapReduceJobSubmissionParameters
        /// class.
        /// </summary>
        public MapReduceJobSubmissionParameters()
        {
        }

        internal string GetJobPostRequestContent()
        {
            // Check input parameters and transform them to required format before sending request to templeton.
            var values = new List<KeyValuePair<string, string>>();

            if (!string.IsNullOrEmpty(this.JarFile))
            {
                values.Add(new KeyValuePair<string, string>("jar", this.JarFile));
            }

            if (!string.IsNullOrEmpty(this.JarClass))
            {
                values.Add(new KeyValuePair<string, string>("class", this.JarClass));
            }

            if (this.Arguments != null && this.Arguments.Count > 0)
            {
                values.AddRange(ModelHelper.BuildList("arg", this.Arguments));
            }

            if (this.Defines != null && this.Defines.Count > 0)
            {
                values.AddRange(ModelHelper.BuildNameValueList("define", this.Defines));
            }

            if (this.LibJars != null && this.LibJars.Count > 0)
            {
                values.Add(new KeyValuePair<string, string>("libjars", ModelHelper.BuildListToCommaSeparatedString(this.LibJars)));
            }

            if (this.Files != null && this.Files.Count > 0)
            {
                values.Add(new KeyValuePair<string, string>("files", ModelHelper.BuildListToCommaSeparatedString(this.Files)));
            }

            values.Add(new KeyValuePair<string, string>("statusdir", ModelHelper.GetStatusDirectory(this.StatusDir)));

            return ModelHelper.ConvertItemsToString(values);
        }
    }
}

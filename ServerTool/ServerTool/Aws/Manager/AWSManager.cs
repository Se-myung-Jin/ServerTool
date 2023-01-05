using System;
using System.Collections.Generic;
using Amazon;
using Amazon.Runtime;

namespace ServerTool

{
    public partial class AwsManager
    {
        public static AwsManager Instance { get; private set; }

        private readonly AWSCredentials _credentials;

        private AwsManager(string accessKey, string secretKey)
        {
            _credentials = new BasicAWSCredentials(accessKey, secretKey);
        }

        public static void Initialize(AwsConfig config)
        {
            Instance = new AwsManager(config.AccessKey, config.SecretKey);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Gobbi.CoreServices.Properties;
using Gobbi.CoreServices.ExceptionHandling;

namespace Gobbi.CoreServices.Data
{
    class ConnectionString
    {
        private const char CONNSTRING_DELIM = ';';
		private string connectionString;
		private string connectionStringWithoutCredentials = null;
        private const string userIdTokens = "user id=,uid=";
		private const string passwordTokens = "password=,pwd=";

		public ConnectionString(string connectionString)
		{
			if (string.IsNullOrEmpty(connectionString)) throw new GobbiTechnicalException ("", new  ArgumentException(Resources.ERROR_EMPTYPARAMETERNAME, "connectionString"));
			this.connectionString = connectionString;
		}

		public string UserName
		{
			get
			{
				string lowConnString = connectionString.ToLower(CultureInfo.CurrentCulture);
				int uidPos;
				int uidMPos;

				GetTokenPositions(userIdTokens, out uidPos, out uidMPos);
				if (0 <= uidPos)
				{
					// found a user id, so pull out the value
					int uidEPos = lowConnString.IndexOf(CONNSTRING_DELIM, uidMPos);
					return connectionString.Substring(uidMPos, uidEPos - uidMPos);
				}
				else
				{
					return String.Empty;
				}
			}
			set
			{
				string lowConnString = connectionString.ToLower(CultureInfo.CurrentCulture);
				int uidPos;
				int uidMPos;
				GetTokenPositions(userIdTokens, out uidPos, out uidMPos);
				if (0 <= uidPos)
				{
					// found a user id, so replace the value
					int uidEPos = lowConnString.IndexOf(CONNSTRING_DELIM, uidMPos);
					connectionString = connectionString.Substring(0, uidMPos) +
						value + connectionString.Substring(uidEPos);

				}
				else
				{
					//no user id in the connection string so just append to the connection string
					string[] tokens = userIdTokens.Split(',');
					connectionString += tokens[0] + value + CONNSTRING_DELIM;
				}
			}
		}

		public string Password
		{
			get
			{

				string lowConnString = connectionString.ToLower(CultureInfo.CurrentCulture);
				int pwdPos;
				int pwdMPos;
				GetTokenPositions(passwordTokens, out pwdPos, out pwdMPos);

				if (0 <= pwdPos)
				{
					// found a password, so pull out the value
					int pwdEPos = lowConnString.IndexOf(CONNSTRING_DELIM, pwdMPos);
					return connectionString.Substring(pwdMPos, pwdEPos - pwdMPos);
				}
				else
				{
					return String.Empty;
				}
			}
			set
			{
				string lowConnString = connectionString.ToLower(CultureInfo.CurrentCulture);
				int pwdPos;
				int pwdMPos;
				GetTokenPositions(passwordTokens, out pwdPos, out pwdMPos);

				if (0 <= pwdPos)
				{
					// found a password, so replace the value
					int pwdEPos = lowConnString.IndexOf(CONNSTRING_DELIM, pwdMPos);
					connectionString = connectionString.Substring(0, pwdMPos) + value + connectionString.Substring(pwdEPos);

				}
				else
				{
					//no password in the connection string so just append to the connection string
					string[] tokens = passwordTokens.Split(',');
					connectionString += tokens[0] + value + CONNSTRING_DELIM;
				}
			}
		}

		public override string ToString()
		{
			return connectionString;
		}

		public string ToStringNoCredentials()
		{
			if (connectionStringWithoutCredentials == null)
				connectionStringWithoutCredentials = RemoveCredentials(connectionString);
			return connectionStringWithoutCredentials;
		}

		private void GetTokenPositions(string tokenString, out int tokenPos, out int tokenMPos)
		{
			string[] tokens = tokenString.Split(',');
			int currentPos = -1;
			int previousPos = -1;
			string lowConnString = connectionString.ToLower(CultureInfo.CurrentCulture);

			//initialze output parameter
			tokenPos = -1;
			tokenMPos = -1;
			foreach (string token in tokens)
			{
				currentPos = lowConnString.IndexOf(token);
				if (currentPos > previousPos)
				{
					tokenPos = currentPos;
					tokenMPos = currentPos + token.Length;
					previousPos = currentPos;
				}
			}
		}

		private string RemoveCredentials(string connectionStringToModify)
		{
			StringBuilder connStringNoCredentials = new StringBuilder();

			string[] tokens = connectionStringToModify.ToLower(CultureInfo.CurrentCulture).Split(CONNSTRING_DELIM);

			string thingsToRemove = userIdTokens + "," + passwordTokens;
			string[] avoidTokens = thingsToRemove.ToLower(CultureInfo.CurrentCulture).Split(',');

			foreach (string section in tokens)
			{
				bool found = false;
				string token = section.Trim();
				if (token.Length != 0)
				{
					foreach (string avoidToken in avoidTokens)
					{
						if (token.StartsWith(avoidToken))
						{
							found = true;
							break;
						}
					}
					if (!found)
					{
						connStringNoCredentials.Append(token + CONNSTRING_DELIM);
					}
				}
			}
			return connStringNoCredentials.ToString();
		}
	
    }
}

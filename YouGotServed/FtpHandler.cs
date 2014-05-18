///////////////////////////////////////
#region Namespace Directives

using System.IO;
using System.Net;
using System.Text;

#endregion
///////////////////////////////////////

namespace YouGotServed
{
    public static class FtpHandler
    {
        ////////////////////////////////////////
        #region Upload Actions

        /// <summary>
        /// Uploads a file to the server.
        /// </summary>
        /// <param name="username">The username for this FTP user.</param>
        /// <param name="password">The password for this FTP user.</param>
        /// <param name="domain">The name of the domain to which data is being transferred.</param>
        /// <param name="targetDirectory">The path (separated from domain) the file is being sent to, with escapes as needed.</param>
        /// <param name="file">The name of the file/folder to be uploaded, with extension.</param>
        /// <param name="source">Indicates the path from which the file is to be uploaded from.</param>
        /// <returns>The status of the file upload.</returns>
        /// <remarks>
        /// Referenced, with modifications for proper implementation, from: "How to: Upload Files with FTP" on MSDN
        /// Link: http://msdn.microsoft.com/en-us/library/ms229715(v=vs.100).aspx
        /// Accessed: 8/13/13
        /// </remarks>
        public static string UploadFileToServer(string username, string password, string domain, string targetDirectory, string file, string source)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + username + ":" + password + "@ftp." + domain + targetDirectory + "/" + file);
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential(username, password);

                StreamReader sourceStream = new StreamReader(source);
                byte[] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
                sourceStream.Close();
                request.ContentLength = fileContents.Length;

                Stream requestStream = request.GetRequestStream();
                requestStream.Write(fileContents, 0, fileContents.Length);
                requestStream.Close();

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                response.Close();

                return file + " upload complete. Status: " + response.StatusDescription.Trim();
            }
            catch
            {
                return "There was an error uploading " + file + " to server.";
            }
        }

        /// <summary>
        /// Creates a directory on the server.
        /// </summary>
        /// <param name="username">The username for this FTP user.</param>
        /// <param name="password">The password for this FTP user.</param>
        /// <param name="domain">The name of the domain to which data is being transferred.</param>
        /// <param name="directoryName">The name of the directory being created.</param>
        /// <returns>The status of directory creation.</returns>
        public static string CreateDirectoryOnServer(string username, string password, string domain, string directoryName)
        {
            try
            {
                WebRequest request = WebRequest.Create("ftp://" + username + ":" + password + "@ftp." + domain + "/" + directoryName);
                request.Method = WebRequestMethods.Ftp.MakeDirectory;
                request.Credentials = new NetworkCredential(username, password);
                using (var response = (FtpWebResponse)request.GetResponse())
                {
                    response.Close();
                    return (response.StatusCode).ToString();
                }
            }
            catch (WebException exception)
            {
                FtpWebResponse response = (FtpWebResponse)exception.Response;
                if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                {
                    response.Close();
                    return directoryName + " already exists on server.";
                }
                else
                {
                    response.Close();
                    return "There was an error creating " + directoryName + " on server.";
                }
            }
        }

        #endregion
    }
}

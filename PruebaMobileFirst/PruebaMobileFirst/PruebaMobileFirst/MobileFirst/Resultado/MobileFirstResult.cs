using System;
namespace PruebaMobileFirst.MobileFirst.Resultado
{
	public class MobileFirstResult
	{
		/// <summary>
		/// Is Success return.
		/// </summary>
		public bool Success { get; set; }

		/// <summary>
		/// JSON message from server return.
		/// </summary>
		public string Message { get; set; }

		/// <summary>
		/// Response for the server message.
		/// </summary>
		public string Response { get; set; }

        /// <summary>
        /// Gets or sets the code status.
        /// </summary>
        /// <value>The code status.</value>
		public int CodeStatus { get; set; }
	}
}

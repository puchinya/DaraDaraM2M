using System;
using DaraDaraM2M.Data;

namespace DaraDaraM2M
{
	public class OM2MException : Exception
	{
		public OM2MException()
		{
			ResponseStatusCode = OM2MResponseStatusCode.InternalServerError;
		}

		public OM2MException(OM2MResponseStatusCode responseStatusCode)
		{
			ResponseStatusCode = responseStatusCode;
		}

		public OM2MException(string message, OM2MResponseStatusCode responseStatusCode)
			: base(message)
		{
			ResponseStatusCode = responseStatusCode;
		}

		public OM2MException(string message, Exception innerException, OM2MResponseStatusCode responseStatusCode)
			: base(message, innerException)
		{
			ResponseStatusCode = responseStatusCode;
		}

		public OM2MResponseStatusCode ResponseStatusCode
		{
			get;
			private set;
		}
	}

	public class OM2MBadRequestException : OM2MException
	{
		public OM2MBadRequestException()
			: base(OM2MResponseStatusCode.BadRequest)
		{
		}

		public OM2MBadRequestException(string message)
			: base(message, OM2MResponseStatusCode.BadRequest)
		{
		}

		public OM2MBadRequestException(string message, Exception innerException)
			: base(message, innerException, OM2MResponseStatusCode.BadRequest)
		{
		}
	}

	public class OM2MNotFoundException : OM2MException
	{
		public OM2MNotFoundException()
			: base(OM2MResponseStatusCode.NotFound)
		{
		}

		public OM2MNotFoundException(string message)
			: base(message, OM2MResponseStatusCode.NotFound)
		{
		}

		public OM2MNotFoundException(string message, Exception innerException)
			: base(message, innerException, OM2MResponseStatusCode.NotFound)
		{
		}
	}

	public class OM2MOperationNotAllowedException : OM2MException
	{
		public OM2MOperationNotAllowedException()
			: base(OM2MResponseStatusCode.OperationNotAllowed)
		{
		}

		public OM2MOperationNotAllowedException(string message)
			: base(message, OM2MResponseStatusCode.OperationNotAllowed)
		{
		}

		public OM2MOperationNotAllowedException(string message, Exception innerException)
			: base(message, innerException, OM2MResponseStatusCode.OperationNotAllowed)
		{
		}
	}

	public class OM2MRequestTimeoutException : OM2MException
	{
		public OM2MRequestTimeoutException()
			: base(OM2MResponseStatusCode.RequestTimeout)
		{
		}

		public OM2MRequestTimeoutException(string message)
			: base(message, OM2MResponseStatusCode.RequestTimeout)
		{
		}

		public OM2MRequestTimeoutException(string message, Exception innerException)
			: base(message, innerException, OM2MResponseStatusCode.RequestTimeout)
		{
		}
	}

	public class OM2MNotImplementedException : OM2MException
	{
		public OM2MNotImplementedException()
			: base(OM2MResponseStatusCode.NotImplemented)
		{
		}

		public OM2MNotImplementedException(string message)
			: base(message, OM2MResponseStatusCode.SparqlUpdateError)
		{
		}

		public OM2MNotImplementedException(string message, Exception innerException)
			: base(message, innerException, OM2MResponseStatusCode.NotImplemented)
		{
		}
	}
}

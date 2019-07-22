﻿using NewRelic.Agent.Core.Api;
using NewRelic.Agent.Extensions.Parsing;
using NewRelic.Agent.Extensions.Providers.Wrapper;
using NewRelic.Core.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace NewRelic.Agent.Core.Wrapper.AgentWrapperApi.Builders
{
	public class NoOpTransaction : ITransaction
	{
		public bool IsValid => false;
		public bool IsFinished => false;
		public ISegment CurrentSegment => Segment.NoOpSegment;

		public void End(bool captureResponseTime = true)
		{
		}

		public void Dispose()
		{
		}

		public ISegment StartCustomSegment(MethodCall methodCall, string segmentName)
		{
#if DEBUG
			Log.Finest("Skipping StartCustomSegment outside of a transaction");
#endif
			return Segment.NoOpSegment;
		}

		public ISegment StartDatastoreSegment(MethodCall methodCall, ParsedSqlStatement parsedSqlStatement, ConnectionInfo connectionInfo, string commandText, IDictionary<string, IConvertible> queryParameters = null, bool isLeaf = false)
		{
#if DEBUG
			Log.Finest("Skipping StartDatastoreSegment outside of a transaction");
#endif
			return Segment.NoOpSegment;
		}

		public ISegment StartExternalRequestSegment(MethodCall methodCall, Uri destinationUri, string method, bool isLeaf = false)
		{
#if DEBUG
			Log.Finest("Skipping StartExternalRequestSegment outside of a transaction");
#endif
			return Segment.NoOpSegment;
		}

		public ISegment StartMessageBrokerSegment(MethodCall methodCall, MessageBrokerDestinationType destinationType, MessageBrokerAction operation, string brokerVendorName, string destinationName)
		{
#if DEBUG
			Log.Finest("Skipping StartMessageBrokerSegment outside of a transaction");
#endif
			return Segment.NoOpSegment;
		}

		public ISegment StartMethodSegment(MethodCall methodCall, string typeName, string methodName, bool isLeaf = false)
		{
#if DEBUG
			Log.Finest("Skipping StartMethodSegment outside of a transaction");
#endif
			return Segment.NoOpSegment;
		}

		public ISegment StartTransactionSegment(MethodCall methodCall, string segmentDisplayName)
		{
#if DEBUG
			Log.Finest("Skipping StartTransactionSegment outside of a transaction");
#endif
			return Segment.NoOpSegment;
		}

		public IEnumerable<KeyValuePair<string, string>> GetResponseMetadata()
		{
			Log.Debug("Tried to retrieve CAT response metadata, but there was no transaction");

			return Enumerable.Empty<KeyValuePair<string, string>>();
		}

		public IEnumerable<KeyValuePair<string, string>> GetRequestMetadata()
		{
			Log.Debug("Tried to retrieve CAT request metadata, but there was no transaction");

			return Enumerable.Empty<KeyValuePair<string, string>>();
		}

		public void AcceptDistributedTracePayload(string payload, TransportType transportType)
		{
			Log.Debug("Tried to accept distributed trace payload, but there was no transaction");
		}

		public IDistributedTraceApiModel CreateDistributedTracePayload()
		{
			Log.Debug("Tried to create distributed trace payload, but there was no transaction");

			return DistributedTraceApiModel.EmptyModel;
		}

		public void NoticeError(Exception exception)
		{
			Log.Debug($"Ignoring application error because it occurred outside of a transaction: {exception}");
		}

		public void SetHttpResponseStatusCode(int statusCode, int? subStatusCode = null)
		{

		}

		public void AttachToAsync()
		{
		}

		public void Detach()
		{
		}

		public void DetachFromPrimary()
		{
		}

		public void ProcessInboundResponse(IEnumerable<KeyValuePair<string, string>> headers, ISegment segment)
		{
				
		}

		public void Hold()
		{

		}

		public void Release()
		{

		}

		public void SetWebTransactionName(WebTransactionType type, string name, TransactionNamePriority priority = TransactionNamePriority.Uri)
		{

		}

		public void SetWebTransactionNameFromPath(WebTransactionType type, string path)
		{

		}

		public void SetMessageBrokerTransactionName(MessageBrokerDestinationType destinationType, string brokerVendorName, string destination = null, TransactionNamePriority priority = TransactionNamePriority.Uri)
		{

		}

		public void SetOtherTransactionName(string category, string name, TransactionNamePriority priority = TransactionNamePriority.Uri)
		{

		}

		public void SetCustomTransactionName(string name, TransactionNamePriority priority = TransactionNamePriority.Uri)
		{

		}

		public void SetUri(string uri)
		{

		}

		public void SetOriginalUri(string uri)
		{

		}

		public void SetReferrerUri(string uri)
		{

		}

		public void SetQueueTime(TimeSpan queueTime)
		{

		}

		public void SetRequestParameters(IEnumerable<KeyValuePair<string, string>> parameters)
		{

		}

		public object GetOrSetValueFromCache(string key, Func<object> func)
		{
			return null;
		}

		public void LogFinest(string message)
		{
			if (Log.IsFinestEnabled)
			{
				Log.Finest($"Trx Noop: {message}");
			}
		}

		public void Ignore()
		{
		}

		public ParsedSqlStatement GetParsedDatabaseStatement(DatastoreVendor vendor, CommandType commandType, string sql)
		{
			return null;
		}
	}
}
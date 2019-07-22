﻿using System;
using System.Collections.Generic;
using System.Security;

namespace NewRelic.SystemInterfaces
{
	public interface IEnvironment
	{
		/// <summary>
		/// Retrieves the value of an environment variable from the current process.
		/// </summary>
		/// <param name="variable">The name of the environment variable.</param>
		/// <returns>The value of the environment variable specified by variable, or null if the environment variable is not found.</returns>
		/// <exception cref="ArgumentNullException">variable is null.</exception>
		/// <exception cref="SecurityException">The caller does not have the required permission to perform this operation.</exception>
		string GetEnvironmentVariable(string variable);

		/// <summary>
		/// Retrieves the value of an environment variable from the current process located in the specified target.
		/// </summary>
		/// <param name="variable">The name of the environment variable.</param>
		/// <param name="environmentVariableTarget">The environment variable location to use.</param>
		/// <returns>The value of the environment variable specified by variable, or null if the environment variable is not found.</returns>
		/// <exception cref="ArgumentNullException">variable is null.</exception>
		/// <exception cref="SecurityException">The caller does not have the required permission to perform this operation.</exception>
		string GetEnvironmentVariable(string variable, EnvironmentVariableTarget environmentVariableTarget);

		/// <summary>
		/// Retrieves the value of an environment variable with specified prefix from the current process located in the specified target.
		/// </summary>
		/// <param name="prefix">prefix.</param>
		/// <returns>Return a dictionary of environment variables that have the prefix matches with the specified prefix, or null if the environment variable is not found.</returns>
		/// <exception cref="ArgumentNullException">prefix is null.</exception>
		/// <exception cref="SecurityException">The caller does not have the required permission to perform this operation.</exception>
		Dictionary<string, string> GetEnvironmentVariablesWithPrefix(string prefix);

	}
}

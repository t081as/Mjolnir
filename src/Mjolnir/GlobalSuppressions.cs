// The MIT License (MIT)
//
// Copyright © 2017-2020 Tobias Koch
//
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the “Software”), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.

// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2225:Operator overloads have named alternates", Justification = "Value property can be accessed directly", Scope = "member", Target = "~M:Mjolnir.Synchronizable`1.op_Implicit(Mjolnir.Synchronizable`1)~`0")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1716:Identifiers should not match keywords", Justification = "Logger interface shall contain this method", Scope = "member", Target = "~M:Mjolnir.Logging.ILogger.Error(System.String)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1716:Identifiers should not match keywords", Justification = "Logger interface shall contain this method", Scope = "member", Target = "~M:Mjolnir.Logging.ILogger.Error(System.String,System.Exception)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "Exceptions shall be ignored", Scope = "member", Target = "~M:Mjolnir.Logging.LogFactory.LogWriterThread")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "Exceptions shall be ignored", Scope = "member", Target = "~M:Mjolnir.Logging.LogFactory.Dispose(System.Boolean)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "Exceptions shall be ignored", Scope = "member", Target = "~M:Mjolnir.Logging.StreamAppender.Dispose(System.Boolean)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "Exceptions shall be ignored", Scope = "member", Target = "~M:Mjolnir.IO.DefaultConfiguration.TryGetValue``1(System.String,``0@)~System.Boolean")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "Exceptions shall be ignored", Scope = "member", Target = "~M:Mjolnir.IO.DefaultConfiguration.GetValue``1(System.String,``0)~``0")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "Exceptions shall be ignored", Scope = "member", Target = "~M:Mjolnir.IO.DefaultConfiguration.GetValue(System.String,System.String)~System.String")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "Stream shall not be disposed", Scope = "member", Target = "~M:Mjolnir.IO.ConfigurationFile.ReadAsync(System.IO.Stream)~System.Threading.Tasks.Task{Mjolnir.IO.IConfiguration}")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "Stream shall not be disposed", Scope = "member", Target = "~M:Mjolnir.IO.ConfigurationFile.WriteAsync(Mjolnir.IO.IConfiguration,System.IO.Stream)~System.Threading.Tasks.Task")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "Stream shall not be disposed", Scope = "member", Target = "~M:Mjolnir.IO.Author.FromAsync(System.IO.Stream)~System.Threading.Tasks.Task{System.Collections.Generic.IEnumerable{Mjolnir.IO.Author}}")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "All exceptions shall be forwarded to the handler", Scope = "member", Target = "~M:Mjolnir.TaskExtensions.Invoke(System.Threading.Tasks.Task,Mjolnir.IExceptionHandler)")]

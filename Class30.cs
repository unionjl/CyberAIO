﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json.Linq;

// Token: 0x0200003A RID: 58
internal sealed class Class30
{
	// Token: 0x0600016C RID: 364 RVA: 0x0000FFE4 File Offset: 0x0000E1E4
	public static void smethod_0(string string_0, int int_0, JObject jobject_0)
	{
		Class30.Class31 @class = new Class30.Class31();
		@class.jobject_0 = jobject_0;
		@class.string_0 = string_0;
		if (Class30.concurrentDictionary_0.ContainsKey(@class.string_0))
		{
			while (!Class30.concurrentDictionary_0[@class.string_0].ContainsKey("thread"))
			{
				Thread.Sleep(100);
			}
			object objA = true;
			if (Class30.Class33.callSite_0 == null)
			{
				Class30.Class33.callSite_0 = CallSite<Func<CallSite, object, Thread>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(Thread), typeof(Class30)));
			}
			if (object.Equals(objA, Class30.Class33.callSite_0.Target(Class30.Class33.callSite_0, Class30.concurrentDictionary_0[@class.string_0]["thread"]).IsAlive))
			{
				return;
			}
		}
		else
		{
			Class30.concurrentDictionary_0[@class.string_0] = new ConcurrentDictionary<string, object>();
		}
		Class30.concurrentDictionary_0[@class.string_0]["tasks"] = new List<int>();
		if (Class30.Class33.callSite_1 == null)
		{
			Class30.Class33.callSite_1 = CallSite<Func<CallSite, object, List<int>>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(List<int>), typeof(Class30)));
		}
		Class30.Class33.callSite_1.Target(Class30.Class33.callSite_1, Class30.concurrentDictionary_0[@class.string_0]["tasks"]).Add(int_0);
		Class30.concurrentDictionary_0[@class.string_0]["requested"] = false;
		Thread thread = new Thread(new ThreadStart(@class.method_0));
		Class30.concurrentDictionary_0[@class.string_0]["thread"] = thread;
		thread.Start();
	}

	// Token: 0x0600016D RID: 365 RVA: 0x00010198 File Offset: 0x0000E398
	public static void smethod_1(int int_0, string string_0)
	{
		Class30.Class32 @class = new Class30.Class32();
		@class.int_0 = int_0;
		try
		{
			if (string_0 == null)
			{
				using (IEnumerator<KeyValuePair<string, ConcurrentDictionary<string, object>>> enumerator = Class30.concurrentDictionary_0.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						KeyValuePair<string, ConcurrentDictionary<string, object>> keyValuePair = enumerator.Current;
						if (keyValuePair.Value.ContainsKey("tasks"))
						{
							if (Class30.Class35.callSite_0 == null)
							{
								Class30.Class35.callSite_0 = CallSite<Func<CallSite, object, List<int>>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(List<int>), typeof(Class30)));
							}
							if (Class30.Class35.callSite_0.Target(Class30.Class35.callSite_0, keyValuePair.Value["tasks"]).Contains(@class.int_0))
							{
								if (Class30.Class35.callSite_1 == null)
								{
									Class30.Class35.callSite_1 = CallSite<Func<CallSite, object, List<int>>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(List<int>), typeof(Class30)));
								}
								List<int> list = Class30.Class35.callSite_1.Target(Class30.Class35.callSite_1, keyValuePair.Value["tasks"]);
								Predicate<int> match;
								if ((match = @class.predicate_0) == null)
								{
									match = (@class.predicate_0 = new Predicate<int>(@class.method_0));
								}
								list.RemoveAll(match);
							}
						}
					}
					goto IL_193;
				}
			}
			if (Class30.Class35.callSite_2 == null)
			{
				Class30.Class35.callSite_2 = CallSite<Func<CallSite, object, List<int>>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(List<int>), typeof(Class30)));
			}
			Class30.Class35.callSite_2.Target(Class30.Class35.callSite_2, Class30.concurrentDictionary_0[string_0]["tasks"]).RemoveAll(new Predicate<int>(@class.method_1));
			IL_193:;
		}
		catch
		{
		}
	}

	// Token: 0x0600016E RID: 366 RVA: 0x00010374 File Offset: 0x0000E574
	public static HttpResponseMessage smethod_2(string string_0, int int_0, JObject jobject_0, bool bool_0)
	{
		if (Class30.concurrentDictionary_0.ContainsKey(string_0))
		{
			object objA = false;
			if (Class30.Class34.callSite_0 == null)
			{
				Class30.Class34.callSite_0 = CallSite<Func<CallSite, object, Thread>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(Thread), typeof(Class30)));
			}
			if (object.Equals(objA, Class30.Class34.callSite_0.Target(Class30.Class34.callSite_0, Class30.concurrentDictionary_0[string_0]["thread"]).IsAlive))
			{
				Class30.smethod_0(string_0, int_0, jobject_0);
			}
		}
		else
		{
			GClass3.smethod_0("Starting monitor for: " + new Uri(string_0).Authority, "Monitor");
			Class30.smethod_0(string_0, int_0, jobject_0);
		}
		while (!Class30.concurrentDictionary_0[string_0].ContainsKey("tasks"))
		{
			Thread.Sleep(100);
		}
		if (Class30.Class34.callSite_1 == null)
		{
			Class30.Class34.callSite_1 = CallSite<Func<CallSite, object, List<int>>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(List<int>), typeof(Class30)));
		}
		Class30.Class34.callSite_1.Target(Class30.Class34.callSite_1, Class30.concurrentDictionary_0[string_0]["tasks"]).Add(int_0);
		while (!Class30.concurrentDictionary_0[string_0].ContainsKey("response"))
		{
			Thread.Sleep(100);
		}
		if (!bool_0)
		{
			for (;;)
			{
				if (Class30.Class34.callSite_2 == null)
				{
					Class30.Class34.callSite_2 = CallSite<Func<CallSite, object, bool>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(bool), typeof(Class30)));
				}
				if (Class30.Class34.callSite_2.Target(Class30.Class34.callSite_2, Class30.concurrentDictionary_0[string_0]["requested"]))
				{
					break;
				}
				Thread.Sleep(100);
			}
		}
		if (Class30.Class34.callSite_3 == null)
		{
			Class30.Class34.callSite_3 = CallSite<Func<CallSite, object, HttpResponseMessage>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(HttpResponseMessage), typeof(Class30)));
		}
		return Class30.Class34.callSite_3.Target(Class30.Class34.callSite_3, Class30.concurrentDictionary_0[string_0]["response"]);
	}

	// Token: 0x040000C8 RID: 200
	[Dynamic(new bool[]
	{
		false,
		false,
		false,
		false,
		true
	})]
	public static ConcurrentDictionary<string, ConcurrentDictionary<string, dynamic>> concurrentDictionary_0 = new ConcurrentDictionary<string, ConcurrentDictionary<string, object>>();

	// Token: 0x0200003B RID: 59
	private sealed class Class31
	{
		// Token: 0x06000170 RID: 368 RVA: 0x00010584 File Offset: 0x0000E784
		internal void method_0()
		{
			try
			{
				int num = 0;
				JArray jarray_ = GClass0.jarray_0;
				for (;;)
				{
					if (Class30.Class33.callSite_2 == null)
					{
						goto IL_F2;
					}
					IL_12:
					if (Class30.Class33.callSite_2.Target(Class30.Class33.callSite_2, Class30.concurrentDictionary_0[this.string_0]["tasks"]).Count > 0)
					{
						try
						{
							string text;
							if (jarray_.Count > 0)
							{
								if (num > jarray_.Count - 1)
								{
									num = 0;
								}
								text = jarray_[num]["proxy"].ToString();
								num++;
							}
							else
							{
								text = null;
							}
							Class70 @class = new Class70(text, "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/66.0.3359.181 Safari/537.36", 10, true, false, this.jobject_0, false);
							HttpResponseMessage value = @class.method_5(this.string_0, true);
							@class.httpClient_0.Dispose();
							Class30.concurrentDictionary_0[this.string_0]["response"] = value;
							Class30.concurrentDictionary_0[this.string_0]["requested"] = true;
							goto IL_11C;
						}
						catch (ThreadAbortException)
						{
							break;
						}
						catch
						{
							goto IL_11C;
						}
						goto IL_F2;
						IL_11C:
						Thread.Sleep(GClass0.int_0);
						continue;
					}
					break;
					IL_F2:
					Class30.Class33.callSite_2 = CallSite<Func<CallSite, object, List<int>>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(List<int>), typeof(Class30)));
					goto IL_12;
				}
			}
			catch
			{
			}
		}

		// Token: 0x040000C9 RID: 201
		public JObject jobject_0;

		// Token: 0x040000CA RID: 202
		public string string_0;
	}

	// Token: 0x0200003C RID: 60
	private sealed class Class32
	{
		// Token: 0x06000172 RID: 370 RVA: 0x00003A63 File Offset: 0x00001C63
		internal bool method_0(int int_1)
		{
			return int_1 == this.int_0;
		}

		// Token: 0x06000173 RID: 371 RVA: 0x00003A63 File Offset: 0x00001C63
		internal bool method_1(int int_1)
		{
			return int_1 == this.int_0;
		}

		// Token: 0x040000CB RID: 203
		public int int_0;

		// Token: 0x040000CC RID: 204
		public Predicate<int> predicate_0;
	}

	// Token: 0x0200003D RID: 61
	private static class Class33
	{
		// Token: 0x040000CD RID: 205
		public static CallSite<Func<CallSite, object, Thread>> callSite_0;

		// Token: 0x040000CE RID: 206
		public static CallSite<Func<CallSite, object, List<int>>> callSite_1;

		// Token: 0x040000CF RID: 207
		public static CallSite<Func<CallSite, object, List<int>>> callSite_2;
	}

	// Token: 0x0200003E RID: 62
	private static class Class34
	{
		// Token: 0x040000D0 RID: 208
		public static CallSite<Func<CallSite, object, Thread>> callSite_0;

		// Token: 0x040000D1 RID: 209
		public static CallSite<Func<CallSite, object, List<int>>> callSite_1;

		// Token: 0x040000D2 RID: 210
		public static CallSite<Func<CallSite, object, bool>> callSite_2;

		// Token: 0x040000D3 RID: 211
		public static CallSite<Func<CallSite, object, HttpResponseMessage>> callSite_3;
	}

	// Token: 0x0200003F RID: 63
	private static class Class35
	{
		// Token: 0x040000D4 RID: 212
		public static CallSite<Func<CallSite, object, List<int>>> callSite_0;

		// Token: 0x040000D5 RID: 213
		public static CallSite<Func<CallSite, object, List<int>>> callSite_1;

		// Token: 0x040000D6 RID: 214
		public static CallSite<Func<CallSite, object, List<int>>> callSite_2;
	}
}

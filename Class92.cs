﻿using System;

// Token: 0x020000AD RID: 173
internal sealed class Class92 : Interface6
{
	// Token: 0x060004AE RID: 1198 RVA: 0x00027348 File Offset: 0x00025548
	public Class92(Interface6 interface6_1)
	{
		this.interface6_0 = interface6_1;
		this.int_0 = interface6_1.imethod_2();
		this.byte_0 = new byte[this.int_0];
		this.byte_1 = new byte[this.int_0];
		this.byte_2 = new byte[this.int_0];
	}

	// Token: 0x060004AF RID: 1199 RVA: 0x0000516C File Offset: 0x0000336C
	public Interface6 method_0()
	{
		return this.interface6_0;
	}

	// Token: 0x060004B0 RID: 1200 RVA: 0x000273A4 File Offset: 0x000255A4
	public void imethod_1(bool bool_1, Interface1 interface1_0)
	{
		this.bool_0 = bool_1;
		if (interface1_0 is Class95)
		{
			Class95 @class = (Class95)interface1_0;
			byte[] array = @class.method_0();
			if (array.Length != this.int_0)
			{
				throw new ArgumentException("initialisation vector must be the same length as block size");
			}
			Array.Copy(array, 0, this.byte_0, 0, array.Length);
			interface1_0 = @class.method_1();
		}
		this.imethod_5();
		this.interface6_0.imethod_1(this.bool_0, interface1_0);
	}

	// Token: 0x060004B1 RID: 1201 RVA: 0x00005174 File Offset: 0x00003374
	public string imethod_0()
	{
		return this.interface6_0.imethod_0() + "/CBC";
	}

	// Token: 0x060004B2 RID: 1202 RVA: 0x00003AA9 File Offset: 0x00001CA9
	public bool imethod_3()
	{
		return false;
	}

	// Token: 0x060004B3 RID: 1203 RVA: 0x0000518B File Offset: 0x0000338B
	public int imethod_2()
	{
		return this.interface6_0.imethod_2();
	}

	// Token: 0x060004B4 RID: 1204 RVA: 0x00005198 File Offset: 0x00003398
	public int imethod_4(byte[] byte_3, int int_1, byte[] byte_4, int int_2)
	{
		if (!this.bool_0)
		{
			return this.method_2(byte_3, int_1, byte_4, int_2);
		}
		return this.method_1(byte_3, int_1, byte_4, int_2);
	}

	// Token: 0x060004B5 RID: 1205 RVA: 0x000051B9 File Offset: 0x000033B9
	public void imethod_5()
	{
		Array.Copy(this.byte_0, 0, this.byte_1, 0, this.byte_0.Length);
		Array.Clear(this.byte_2, 0, this.byte_2.Length);
		this.interface6_0.imethod_5();
	}

	// Token: 0x060004B6 RID: 1206 RVA: 0x00027418 File Offset: 0x00025618
	private int method_1(byte[] byte_3, int int_1, byte[] byte_4, int int_2)
	{
		if (int_1 + this.int_0 > byte_3.Length)
		{
			throw new Exception1("input buffer too short");
		}
		for (int i = 0; i < this.int_0; i++)
		{
			byte[] array = this.byte_1;
			int num = i;
			array[num] ^= byte_3[int_1 + i];
		}
		int result = this.interface6_0.imethod_4(this.byte_1, 0, byte_4, int_2);
		Array.Copy(byte_4, int_2, this.byte_1, 0, this.byte_1.Length);
		return result;
	}

	// Token: 0x060004B7 RID: 1207 RVA: 0x00027490 File Offset: 0x00025690
	private int method_2(byte[] byte_3, int int_1, byte[] byte_4, int int_2)
	{
		if (int_1 + this.int_0 > byte_3.Length)
		{
			throw new Exception1("input buffer too short");
		}
		Array.Copy(byte_3, int_1, this.byte_2, 0, this.int_0);
		int result = this.interface6_0.imethod_4(byte_3, int_1, byte_4, int_2);
		for (int i = 0; i < this.int_0; i++)
		{
			int num = int_2 + i;
			byte_4[num] ^= this.byte_1[i];
		}
		byte[] array = this.byte_1;
		this.byte_1 = this.byte_2;
		this.byte_2 = array;
		return result;
	}

	// Token: 0x04000243 RID: 579
	private byte[] byte_0;

	// Token: 0x04000244 RID: 580
	private byte[] byte_1;

	// Token: 0x04000245 RID: 581
	private byte[] byte_2;

	// Token: 0x04000246 RID: 582
	private int int_0;

	// Token: 0x04000247 RID: 583
	private Interface6 interface6_0;

	// Token: 0x04000248 RID: 584
	private bool bool_0;
}

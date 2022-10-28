﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocol
{
	static public class Generater
	{
		// List<byte>

		// 일반 자료형
		// int
		static public void Generate(int target, ref ByteList destination)
		{
			// 해석하기 위한 데이터 삽입
			destination.Add(DataType.INT);

			// int 형 데이터를 해당 byte 형으로 변환
			destination.AddRange(BitConverter.GetBytes(target));
		}
		static public ByteList Generate(int target)
		{
			ByteList destination = new();
			Generate(target, ref destination);
			return destination;
		}


		// string
		static public void Generate(string target, ref ByteList destination)
		{
			// 해석하기 위한 데이터 삽입
			destination.Add(DataType.STRING);

			// 문자열의 길이 삽입
			destination.AddRange(BitConverter.GetBytes(target.Length));

			// 문자열의 내용 삽입
			destination.AddRange(Encoding.UTF8.GetBytes(target));
		}
		static public ByteList Generate(string target)
		{
			ByteList destination = new();
			Generate(target, ref destination);
			return destination;
		}

		// bool
		static public void Generate(bool target, ref ByteList destination)
		{
			// 해석하기 위한 데이터 삽입
			destination.Add(DataType.BOOL);

			// int 형 데이터를 해당 byte 형으로 변환
			destination.AddRange(BitConverter.GetBytes(target));
		}
		static public ByteList Generate(bool target)
		{
			ByteList destination = new();
			Generate(target, ref destination);
			return destination;
		}

		// 제어 데이터형
		// Login
		static public void Generate(LoginProtocol.Login target, ref ByteList destination)
		{
			LoginProtocol.Generate(target, ref destination);
			return;
		}
		static public ByteList Generate(LoginProtocol.Login target)
		{
			ByteList destination = new();
			Generate(target, ref destination);
			return destination;
		}

		// Login
		static public void Generate(LogoutProtocol.Logout target, ref ByteList destination)
		{
			LogoutProtocol.Generate(target, ref destination);
			return;
		}
		static public ByteList Generate(LogoutProtocol.Logout target)
		{
			ByteList destination = new();
			Generate(target, ref destination);
			return destination;
		}

		// IsConnect
		static public void Generate(isConnectProtocol.IsConnect target, ref ByteList destination)
		{
			isConnectProtocol.Generate(target, ref destination);
			return;
		}
		static public ByteList Generate(isConnectProtocol.IsConnect target)
		{
			ByteList destination = new();
			Generate(target, ref destination);
			return destination;
		}

		// 클래스 형
		// User
		static public void Generate(UserInfoProtocol.User target, ref ByteList destination)
		{
			UserInfoProtocol.Generate(target, ref destination);
			return;
		}
		static public ByteList Generate(UserInfoProtocol.User target)
		{
			ByteList destination = new();
			Generate(target, ref destination);
			return destination;
		}

		// Message
		static public void Generate(MessageProtocol.Message target, ref ByteList destination)
		{
			MessageProtocol.Generate(target, ref destination);
			return;
		}
		static public ByteList Generate(MessageProtocol.Message target)
		{
			ByteList destination = new();
			Generate(target, ref destination);
			return destination;
		}
	}
}
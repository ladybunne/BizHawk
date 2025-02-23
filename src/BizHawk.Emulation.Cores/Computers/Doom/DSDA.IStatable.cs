﻿using System.IO;

using BizHawk.Emulation.Common;

namespace BizHawk.Emulation.Cores.Computers.Doom
{
	public partial class DSDA : IStatable
	{
		public bool AvoidRewind => false;

		public void LoadStateBinary(BinaryReader reader)
		{
			_elf.LoadStateBinary(reader);
			
			// Getting last mouse positions
			_turnHeld[0] = reader.ReadInt32();
			_turnHeld[1] = reader.ReadInt32();
			_turnHeld[2] = reader.ReadInt32();
			_turnHeld[3] = reader.ReadInt32();

			Frame = reader.ReadInt32();
			// any managed pointers that we sent to the core need to be resent now!
			//Core.stella_set_input_callback(_inputCallback);
			UpdateVideo();
		}

		public void SaveStateBinary(BinaryWriter writer)
		{
			_elf.SaveStateBinary(writer);

			// Writing last mouse positions
			writer.Write(_turnHeld[0]);
			writer.Write(_turnHeld[1]);
			writer.Write(_turnHeld[2]);
			writer.Write(_turnHeld[3]);

			writer.Write(Frame);
		}
	}
}

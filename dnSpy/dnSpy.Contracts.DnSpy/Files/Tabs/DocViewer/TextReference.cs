﻿/*
    Copyright (C) 2014-2016 de4dot@gmail.com

    This file is part of dnSpy

    dnSpy is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    dnSpy is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with dnSpy.  If not, see <http://www.gnu.org/licenses/>.
*/

using dnSpy.Decompiler.Shared;
using Microsoft.VisualStudio.Text;

namespace dnSpy.Contracts.Files.Tabs.DocViewer {
	/// <summary>
	/// A reference in the text
	/// </summary>
	public sealed class TextReference {
		/// <summary>
		/// Gets the reference or null
		/// </summary>
		public object Reference { get; }

		/// <summary>
		/// Gets the flags
		/// </summary>
		public DecompilerReferenceFlags Flags { get; }

		/// <summary>
		/// true if it's a local, parameter, or label
		/// </summary>
		public bool IsLocal => (Flags & DecompilerReferenceFlags.Local) != 0;

		/// <summary>
		/// true if it's a definition
		/// </summary>
		public bool IsDefinition => (Flags & DecompilerReferenceFlags.Definition) != 0;

		/// <summary>
		/// true if it's a write to a reference
		/// </summary>
		public bool IsWrite => (Flags & DecompilerReferenceFlags.IsWrite) != 0;

		/// <summary>
		/// Gets the span or null if it's unknown
		/// </summary>
		public Span? Span { get; }

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="reference">Reference or null</param>
		public TextReference(object reference)
			: this(reference, DecompilerReferenceFlags.None) {
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="reference">Reference or null</param>
		/// <param name="span">Span</param>
		public TextReference(object reference, Span span)
			: this(reference, DecompilerReferenceFlags.None, span) {
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="reference">Reference or null</param>
		/// <param name="flags">Flags</param>
		public TextReference(object reference, DecompilerReferenceFlags flags) {
			this.Reference = reference;
			this.Flags = flags;
			this.Span = null;
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="reference">Reference or null</param>
		/// <param name="flags">Flags</param>
		/// <param name="span">Span</param>
		public TextReference(object reference, DecompilerReferenceFlags flags, Span span) {
			this.Reference = reference;
			this.Flags = flags;
			this.Span = span;
		}
	}
}
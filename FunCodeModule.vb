Module FunCode
    <System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit)> Structure MyUnion
        ' C语言union
        <System.Runtime.InteropServices.FieldOffset(0)> Dim b As Byte '单字节整数  
        <System.Runtime.InteropServices.FieldOffset(0)> Dim s As Short '双字节整数  
        <System.Runtime.InteropServices.FieldOffset(0)> Dim i As Integer '四字节整数  

    End Structure

    <System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit)> Structure Union_BIU
        ' 快速简便实现 Integer 转Uinteger
        <System.Runtime.InteropServices.FieldOffset(0)> Dim b1 As Byte '单字节整数  
        <System.Runtime.InteropServices.FieldOffset(1)> Dim b2 As Byte '单字节整数
        <System.Runtime.InteropServices.FieldOffset(2)> Dim b3 As Byte '单字节整数
        <System.Runtime.InteropServices.FieldOffset(3)> Dim b4 As Byte '单字节整数

        <System.Runtime.InteropServices.FieldOffset(0)> Dim i As Integer '四字节整数  
        <System.Runtime.InteropServices.FieldOffset(0)> Dim Ui As UInteger '四字节整数 

    End Structure

    <System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit)> Structure Union_BSU
        ' 快速简便实现 Integer 转Uinteger
        <System.Runtime.InteropServices.FieldOffset(0)> Dim b1 As Byte '单字节整数  
        <System.Runtime.InteropServices.FieldOffset(1)> Dim b2 As Byte '单字节整数

        <System.Runtime.InteropServices.FieldOffset(0)> Dim si As Short '四字节整数  
        <System.Runtime.InteropServices.FieldOffset(0)> Dim Usi As UShort '四字节整数  

    End Structure

    Sub TestUnion()
        Dim SToUs As New Union_BSU
        SToUs.b1 = &HFF
        SToUs.b2 = &HFF
        Console.WriteLine(SToUs.si)
        Console.WriteLine(SToUs.Usi)

        SToUs.si = Short.MinValue
        Console.WriteLine(SToUs.b1.ToString("X2"))
        Console.WriteLine(SToUs.b2.ToString("X2"))
        Console.WriteLine(SToUs.Usi)
        SToUs.si = -213

        Dim uu As New MyUnion
        uu.b = 33

        uu.i = -65033
        uu.s = -32733

    End Sub




    ''' <summary>
    ''' 获取变量的地址
    ''' </summary>
    ''' <param name="a"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetPtr(a As Object) As IntPtr
        Dim thObject As System.Runtime.InteropServices.GCHandle = System.Runtime.InteropServices.GCHandle.Alloc(a, System.Runtime.InteropServices.GCHandleType.Pinned)
        Dim p = thObject.AddrOfPinnedObject()
        Return p
    End Function

    Public Declare Function add Lib "D:\su\project\Dll\InfoTextDW\CanBus_vb\Debug\VCDLL3.dll" _
    (ByVal a As Integer, b As Integer) As Integer  'X86
    Public Declare Function addp Lib "D:\su\project\Dll\InfoTextDW\CanBus_vb\Debug\VCDLL3.dll" _
    (ByVal a As IntPtr) As Integer  'X86

    Public Declare Function padd Lib "D:\su\project\Dll\InfoTextDW\CanBus_vb\Debug\VCDLL3.dll" _
(ByVal a As Integer) As IntPtr  'X86

    Sub Call_VCDll()
        MessageBox.Show(add(5, 6))
        Static p As New IntPtr
        Dim a As Int32 = 2
        p = GetPtr(a)
        MessageBox.Show(addp(p))
        Dim b = 55
        p = padd(22)
        a = System.Runtime.InteropServices.Marshal.ReadInt32(p, 0)  '从地址获取值
        MessageBox.Show(a)
    End Sub




End Module

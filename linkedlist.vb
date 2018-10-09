Module Module1
    Structure cell
        Dim contents As String
        Dim ptr As Integer
    End Structure

    Dim list(6) As cell 'creates a list of cells, each with a pointer and contents

    'Dim items() As String = {"fox", "gnu", "dog", "cat", "cow"} 'items(4)
    'Dim items() As String = {"cat", "gnu", "cow", "dog", "fox"} 'items(4)
    Dim items() As String = {"pheasant", "teal", "widgeon", "partridge", "woodpegeon", "grouse", "snipe"} 'items(6)

    Dim fsp As Integer = 0 'free space pointer
    Dim dsp As Integer = 999 'data start pointer set to 999 because there is no data currently

    Dim i As Integer 'counter to dictate which item is to be added

    Dim index As Integer 'location where new item will be in the logical order

    Dim lastloc As Integer

    Dim pos As Integer

    Dim oldfsp As Integer

    Sub initList() 'init list ptrs

        For k = 0 To 5
            list(k).ptr = k + 1
        Next

        list(6).ptr = 999 'set last cell to point to rogue value
    End Sub

    Sub addFirst()
        list(0).contents = items(i)
        fsp = 1
        dsp = 0
        list(0).ptr = 999
        'i = i + 1

    End Sub

    Sub printList()
        Console.Clear()

        For n = 0 To 6
            Console.Write(n)
            Console.Write("   ")
            Console.Write(list(n).contents)
            Console.Write("    ")
            Console.Write(list(n).ptr)
            Console.WriteLine("")
        Next

        printptr()
        Console.WriteLine()
    End Sub

    Sub printptr()
        Console.WriteLine()
        Console.Write("fsp = ")
        Console.Write(fsp)
        Console.WriteLine("")
        Console.Write("dsp = ")
        Console.Write(dsp)
    End Sub

    Sub calcPos() 'calculates the position of the new item in the logical order
        index = dsp

        If items(i) < list(dsp).contents Then 'i and dsp
            'item is first in logical order
            pos = 0
        Else
            'calculate position
            While items(i) > list(index).contents And list(index).ptr <> 999
                lastloc = index
                index = list(index).ptr
            End While

            If items(i) > list(index).contents Then
                'item is last in logical order
                pos = 2
            Else
                'item is mid in order
                pos = 1
            End If
        End If
    End Sub

    Sub addItem()
        i = i + 1
        list(fsp).contents = items(i)

        oldfsp = fsp
        fsp = list(fsp).ptr
    End Sub

    Sub updateptr()
        Select Case pos
            Case 0 'item is first in the logical order 
                list(oldfsp).ptr = dsp
                dsp = oldfsp
            Case 1
                'item is mid in logical order
                list(oldfsp).ptr = list(lastloc).ptr
                list(lastloc).ptr = oldfsp
            Case 2
                'item is last in logical order 
                'list(oldfsp).ptr = 999
                list(index).ptr = oldfsp
                list(oldfsp).ptr = 999
        End Select
    End Sub

    Sub Main()
        initList()
        printList()

        Console.ReadLine()

        addFirst()
        printList()

        Console.ReadLine()


        For t = 0 To 5

            addItem()
            calcPos()
            updateptr()
            printList()
            Console.ReadLine()
        Next

        'printList()
        'printptr()

        'test()
        Console.ReadLine()
    End Sub


    'BUGS:
    'none
End Module
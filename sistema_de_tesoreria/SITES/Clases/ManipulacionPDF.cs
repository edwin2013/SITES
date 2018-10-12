using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GUILayer
{
    public class ManipulacionPDF
    {

        public Boolean MergePdfFiles(String[] pdfFiles, String outputPath)
        {



            //                                     Optional ByVal authorName As String = "", _
            //                                     Optional ByVal creatorName As String = "", _
            //                                     Optional ByVal subject As String = "", _
            //                                     Optional ByVal title As String = "", _
            //                                     Optional ByVal keywords As String = "") 
            Boolean result = false;
            int pdfCount = 0;                             //'total input pdf file count
            int f = 0;                                   //'pointer to current input pdf file
            string fileName = String.Empty;              // 'current input pdf filename
            iTextSharp.text.pdf.PdfReader reader = null;
            int pageCount = 0;                     //'cureent input pdf page count
            iTextSharp.text.Document pdfDoc = null;         //   'the output pdf document
            iTextSharp.text.pdf.PdfWriter writer = null;
            iTextSharp.text.pdf.PdfContentByte cb = null;
            //    'Declare a variable to hold the imported pages
            iTextSharp.text.pdf.PdfImportedPage page = null;
            int rotation = 0;
            bool unethicalreading = false;
            //    'Declare a font to used for the bookmarks
            iTextSharp.text.Font bookmarkFont = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, 12, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLUE);
            
            // Try
            pdfCount = pdfFiles.Length;
            if (pdfCount > 1)
            {
                //            'Open the 1st pad using PdfReader object
                fileName = pdfFiles[f];
                reader = new iTextSharp.text.pdf.PdfReader(fileName);
               // reader.
                iTextSharp.text.pdf.PdfReader.unethicalreading = unethicalreading; 
                //            'Get page count
                pageCount = reader.NumberOfPages;

                //            'Instantiate an new instance of pdf document and set its margins. This will be the output pdf.
                //            'NOTE: bookmarks will be added at the 1st page of very original pdf file using its filename. The location
                //            'of this bookmark will be placed at the upper left hand corner of the document. So you'll need to adjust
                //            'the margin left and margin top values such that the bookmark won't overlay on the merged pdf page. The 
                //            'unit used is "points" (72 points = 1 inch), thus in this example, the bookmarks' location is at 1/4 inch from
                //            'left and 1/4 inch from top of the page.

                pdfDoc = new iTextSharp.text.Document(reader.GetPageSizeWithRotation(1), 18, 18, 18, 18);
                //            'Instantiate a PdfWriter that listens to the pdf document
                writer = iTextSharp.text.pdf.PdfWriter.GetInstance(pdfDoc, new System.IO.FileStream(outputPath, System.IO.FileMode.Create));    //added system
                //            'Set metadata and open the document
                // With pdfDoc
                pdfDoc.AddAuthor("");
                pdfDoc.AddCreationDate();
                pdfDoc.AddCreator("");
                pdfDoc.AddProducer();
                pdfDoc.AddSubject("");
                pdfDoc.AddTitle("");
                pdfDoc.AddKeywords("");
                pdfDoc.Open();
                //  End With
                //            'Instantiate a PdfContentByte object
                cb = writer.DirectContent;
                //            'Now loop thru the input pdfs
                while (f < pdfCount)
                {

                    //                'Declare a page counter variable
                    int i = 0;
                    //                'Loop thru the current input pdf's pages starting at page 1
                    while (i < pageCount)
                    {
                        i += 1;
                        //                    'Get the input page size
                        pdfDoc.SetPageSize(reader.GetPageSizeWithRotation(i));
                        //                    'Create a new page on the output document
                        pdfDoc.NewPage();

                        //                    'If it is the 1st page, we add bookmarks to the page
                        //                    'If i = 1 Then
                        //                    '    'First create a paragraph using the filename as the heading
                        //                    '    Dim para As New iTextSharp.text.Paragraph(IO.Path.GetFileName(fileName).ToUpper(), bookmarkFont)
                        //                    '    'Then create a chapter from the above paragraph
                        //                    '    Dim chpter As New iTextSharp.text.Chapter(para, f + 1)
                        //                    '    'Finally add the chapter to the document
                        //                    '    pdfDoc.Add(chpter)
                        //                    'End If

                        //                    'Now we get the imported page

                       
                        page = writer.GetImportedPage(reader, i);
                        //                    'Read the imported page's rotation
                        rotation = reader.GetPageRotation(i);
                        //                    'Then add the imported page to the PdfContentByte object as a template based on the page's rotation
                        if (rotation == 90)
                        {
                            cb.AddTemplate(page, 0, -1.0F, 1.0F, 0, 0, reader.GetPageSizeWithRotation(i).Height);
                        }
                        else
                            if (rotation == 270)
                            {
                                cb.AddTemplate(page, 0, 1.0F, -1.0F, 0, reader.GetPageSizeWithRotation(i).Width + 60, -30);


                            }
                            else
                            {
                                cb.AddTemplate(page, 1.0F, 0, 0, 1.0F, 0, 0);
                            }

                    } //End While 2

                    //                'Increment f and read the next input pdf file
                    f += 1;
                    if (f < pdfCount)
                    {
                        fileName = pdfFiles[f];
                        reader = new iTextSharp.text.pdf.PdfReader(fileName);
                        pageCount = reader.NumberOfPages;
                    } //   End If
                }        //end while 1
                //            'When all done, we close the document so that the pdfwriter object can write it to the output file
                pdfDoc.Close();
                result = true;
            }//        End If Principal
            //    Catch ex As Exception
            //        Throw New Exception(ex.Message)
            //    End Try

            return result;
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="reader"></param>
        ///// <returns></returns>
        //public static PdfReader unlockPdf(PdfReader reader)
        //{
        //    if (reader == null)
        //    {
        //        return reader;
        //    }
        //    try
        //    {
        //        Field f = reader.getClass().getDeclaredField("encrypted");
        //        f.setAccessible(true);
        //        f.set(reader, false);
        //    }
        //    catch (Exception e)
        //    { // ignore
        //    }
        //    return reader;
        //}

    }
}

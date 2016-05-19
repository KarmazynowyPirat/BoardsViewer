//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Windows.UI.Xaml;
//using Windows.UI.Xaml.Controls;
//using Windows.UI.Xaml.Documents;
//using HtmlAgilityPack;

//namespace App1.Models
//{
//    class Properties : DependencyObject
//    {
//        public static readonly DependencyProperty HtmlProperty =
//        DependencyProperty.RegisterAttached("Html", typeof(string), typeof(Properties), new PropertyMetadata(null, HtmlChanged));
//        private static void HtmlChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
//        {
//            RichTextBlock richText = d as RichTextBlock;
//            if (richText == null) return;

//            //Generate blocks
//            string xhtml = e.NewValue as string;

//            string baselink = "";
//            //if (richText.DataContext is BlogPostDataItem)
//            //{
//            //    BlogPostDataItem bp = richText.DataContext as BlogPostDataItem;
//            //    baselink = "http://" + bp.Link.Host;
//            //}

//            List<Block> blocks = GenerateBlocksForHtml(xhtml, baselink);

//            //Add the blocks to the RichTextBlock
//            richText.Blocks.Clear();
//            foreach (Block b in blocks)
//            {
//                richText.Blocks.Add(b);
//            }
//        }
//        private static List<Block> GenerateBlocksForHtml(string xhtml, string baselink)
//        {
//            List<Block> bc = new List<Block>();

//            try
//            {
//                HtmlDocument doc = new HtmlDocument();
//                doc.LoadHtml(xhtml);

//                foreach (HtmlNode img in doc.DocumentNode.Descendants("img"))
//                {
//                    if (!img.Attributes["src"].Value.StartsWith("http"))
//                    {
//                        img.Attributes["src"].Value = baselink + img.Attributes["src"].Value;
//                    }
//                }

//                Block b = GenerateParagraph(doc.DocumentNode);
//                bc.Add(b);
//            }
//            catch (Exception ex)
//            {
//            }

//            return bc;
//        }

//        private static Block GenerateParagraph(HtmlNode node)
//        {
//            Paragraph p = new Paragraph();
//            AddChildren(p, node);
//            return p;
//        }

//        private static void AddChildren(Paragraph p, HtmlNode node)
//        {
//            bool added = false;
//            foreach (HtmlNode child in node.ChildNodes)
//            {
//                Inline i = GenerateBlockForNode(child);
//                if (i != null)
//                {
//                    p.Inlines.Add(i);
//                    added = true;
//                }
//            }
//            //if (!added)
//            //{
//            //    p.Inlines.Add(new Run() { Text = CleanText(node.InnerText) });
//            //}
//        }

//        private static Inline GenerateBlockForNode(HtmlNode node)
//        {
//            switch (node.Name)
//            {
//                case "BR":
//                case "br":
//                    return new LineBreak();
//            }
//            return null;
//        }
//        //private static Inline GenerateSpan(HtmlNode node)
//        //{
//        //    Span s = new Span();
//        //    AddChildren(s, node);
//        //    return s;
//        //}
//    }
//}

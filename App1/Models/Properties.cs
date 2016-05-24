using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Documents;
using HtmlAgilityPack;

namespace App1.Models
{
    public class Properties : DependencyObject
    {
        public static readonly DependencyProperty HtmlProperty =
        DependencyProperty.RegisterAttached("Html", typeof(string), typeof(Properties), new PropertyMetadata(null, HtmlChanged));

        public static void SetHtml(DependencyObject obj, string value)
        {
            obj.SetValue(HtmlProperty, value);
        }
        public static string GetHtml(DependencyObject obj)
        {
            return (string)obj.GetValue(HtmlProperty);
        }

        private static void HtmlChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            RichTextBlock richText = d as RichTextBlock;
            if (richText == null) return;

            //Generate blocks
            string xhtml = e.NewValue as string;
            
            List<Block> blocks = GenerateBlocksForHtml(xhtml);

            //Add the blocks to the RichTextBlock
            richText.Blocks.Clear();
            foreach (Block b in blocks)
            {
                richText.Blocks.Add(b);
            }
        }
        private static List<Block> GenerateBlocksForHtml(string xhtml)
        {
            List<Block> bc = new List<Block>();

            try
            {
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(xhtml);

                //foreach (HtmlNode img in doc.DocumentNode.Descendants("img"))
                //{
                //    if (!img.Attributes["src"].Value.StartsWith("http"))
                //    {
                //        img.Attributes["src"].Value = baselink + img.Attributes["src"].Value;
                //    }
                //}

                Block b = GenerateParagraph(doc.DocumentNode);
                bc.Add(b);
            }
            catch (Exception ex)
            {
            }

            return bc;
        }

        private static Block GenerateParagraph(HtmlNode node)
        {
            Paragraph p = new Paragraph();
            AddChildren(p, node);
            return p;
        }

        private static void AddChildren(Paragraph p, HtmlNode node)
        {
            bool added = false;
            foreach (HtmlNode child in node.ChildNodes)
            {
                Inline i = GenerateBlockForNode(child);
                if (i != null)
                {
                    p.Inlines.Add(i);
                    added = true;
                }
            }
            if (!added)
            {
                p.Inlines.Add(new Run() { Text = CleanText(node.InnerText) });
            }
        }

        private static void AddChildrenSpan(Span p, HtmlNode node)
        {
            bool added = false;
            foreach (HtmlNode child in node.ChildNodes)
            {
                Inline i = GenerateBlockForNode(child);
                if (i != null)
                {
                    p.Inlines.Add(i);
                    added = true;
                }
            }
            if (!added)
            {
                p.Inlines.Add(new Run() { Text = CleanText(node.InnerText) });
            }
        }

        private static Inline GenerateBlockForNode(HtmlNode node)
        {
            switch (node.Name)
            {
                case "BR":
                case "br":
                    return new LineBreak();
                case "#text":
                    if (!string.IsNullOrWhiteSpace(node.InnerText))
                        return new Run() { Text = CleanText(node.InnerText) };
                    break;
                case "span":
                case "Span":
                    return GenerateSpan(node);
                case "a":
                case "A":
                    return GenerateHyperLink(node);
            }
            return null;
        }

        //todo: improve
        private static Inline GenerateHyperLink(HtmlNode node)
        {
            Span s = new Span();
            InlineUIContainer iui = new InlineUIContainer();

            if (node.InnerText.StartsWith("http", StringComparison.CurrentCultureIgnoreCase) ||
                node.InnerText.StartsWith("www", StringComparison.CurrentCultureIgnoreCase))
            {
                HyperlinkButton hb = new HyperlinkButton()
                {
                    NavigateUri = new Uri(node.Attributes["href"].Value, UriKind.Absolute),
                    Content = CleanText(node.InnerText)
                };
                
                //if (node.ParentNode != null && (node.ParentNode.Name == "li" || node.ParentNode.Name == "LI"))
                //    hb.Style = (Style) Application.Current.Resources["RTLinkLI"];
                //else if ((node.NextSibling == null || string.IsNullOrWhiteSpace(node.NextSibling.InnerText)) &&
                //         (node.PreviousSibling == null || string.IsNullOrWhiteSpace(node.PreviousSibling.InnerText)))
                //    hb.Style = (Style) Application.Current.Resources["RTLinkOnly"];
                //else
                //    hb.Style = (Style) Application.Current.Resources["RTLink"];

                iui.Child = hb;
                s.Inlines.Add(iui);
                return s;
            }
            else
            {
                return new Run() { Text = CleanText(node.InnerText) };
            }
        }

        private static string CleanText(string input)
        {
            string clean = Windows.Data.Html.HtmlUtilities.ConvertToText(input);
            if (clean == "\0")
                clean = "\n";
            return clean;
        }
        private static Inline GenerateSpan(HtmlNode node)
        {
            Span s = new Span();
            AddChildrenSpan(s, node);
            return s;
        }
    }
}

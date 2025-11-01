using System;
using Xunit;
using TestStack.BDDfy;
using TestStack.BDDfy.Reporters;
using UPT.DocumentConverters;

namespace UPT.DocumentConverters.Tests
{
    // Pruebas en formato BDD usando TestStack.BDDfy + xUnit.
    public class DocumentConverterFeature
    {
        private string _content;
        private string _format;
        private IDocumentConverter _converter;
        private string _result;
        private Exception _caughtException;

        // --- Scenario: Convert to DOCX ---
        public void Given_a_simple_content()
        {
            _content = "Hello World";
        }

        public void AndGiven_format_is_docx()
        {
            _format = "docx";
        }

        public void When_creating_converter_and_converting()
        {
            _converter = DocumentConverterFactory.CreateDocumentConverter(_format);
            _result = _converter.Convert(_content);
        }

        public void Then_result_should_be_converted_to_docx()
        {
            Assert.Equal("Hello World [Converted to DOCX]", _result);
        }

        public void AndThen_target_extension_should_be_dot_docx()
        {
            Assert.Equal(".docx", _converter.TargetExtension);
        }

        [Fact]
        public void Convert_To_Docx_Scenario()
        {
            var reporters = new IReport[] { new HtmlReporter { ReportsDirectory = "reports/bdd", ReportName = "Docx Conversion" } };
            this.Given(x => Given_a_simple_content())
                .And(x => AndGiven_format_is_docx())
                .When(x => When_creating_converter_and_converting())
                .Then(x => Then_result_should_be_converted_to_docx())
                .And(x => AndThen_target_extension_should_be_dot_docx())
                .BDDfy("Convert to DOCX", reporters);
        }

        // --- Scenario: Convert to PDF (case-insensitive format) ---
        public void AndGiven_format_is_PDF_uppercase()
        {
            _format = "PDF";
        }

        public void Then_result_should_be_converted_to_pdf()
        {
            Assert.Equal("Hello World [Converted to PDF]", _result);
        }

        public void AndThen_target_extension_should_be_dot_pdf()
        {
            Assert.Equal(".pdf", _converter.TargetExtension);
        }

        [Fact]
        public void Convert_To_Pdf_CaseInsensitive_Scenario()
        {
            var reporters = new IReport[] { new HtmlReporter { ReportsDirectory = "reports/bdd", ReportName = "PDF Conversion" } };
            this.Given(x => Given_a_simple_content())
                .And(x => AndGiven_format_is_PDF_uppercase())
                .When(x => {
                    _converter = DocumentConverterFactory.CreateDocumentConverter(_format);
                    _result = _converter.Convert(_content);
                })
                .Then(x => Then_result_should_be_converted_to_pdf())
                .And(x => AndThen_target_extension_should_be_dot_pdf())
                .BDDfy("Convert to PDF (case-insensitive)", reporters);
        }

        // --- Scenario: Convert to TXT ---
        public void AndGiven_format_is_txt()
        {
            _format = "txt";
        }

        public void Then_result_should_be_converted_to_txt()
        {
            Assert.Equal("Hello World [Converted to TXT]", _result);
        }

        public void AndThen_target_extension_should_be_dot_txt()
        {
            Assert.Equal(".txt", _converter.TargetExtension);
        }

        [Fact]
        public void Convert_To_Txt_Scenario()
        {
            var reporters = new IReport[] { new HtmlReporter { ReportsDirectory = "reports/bdd", ReportName = "TXT Conversion" } };
            this.Given(x => Given_a_simple_content())
                .And(x => AndGiven_format_is_txt())
                .When(x => {
                    _converter = DocumentConverterFactory.CreateDocumentConverter(_format);
                    _result = _converter.Convert(_content);
                })
                .Then(x => Then_result_should_be_converted_to_txt())
                .And(x => AndThen_target_extension_should_be_dot_txt())
                .BDDfy("Convert to TXT", reporters);
        }

        // --- Scenario: Unsupported format throws ---
        public void Given_unsupported_format()
        {
            _format = "unknown-format";
        }

        public void When_creating_converter_for_unknown_format()
        {
            try
            {
                _converter = DocumentConverterFactory.CreateDocumentConverter(_format);
            }
            catch (Exception ex)
            {
                _caughtException = ex;
            }
        }

        public void Then_an_argument_exception_should_be_thrown()
        {
            Assert.NotNull(_caughtException);
            Assert.IsType<ArgumentException>(_caughtException);
        }

        [Fact]
        public void Unsupported_Format_Should_Throw()
        {
            var reporters = new IReport[] { new HtmlReporter { ReportsDirectory = "reports/bdd", ReportName = "Unsupported Format" } };
            this.Given(x => Given_unsupported_format())
                .When(x => When_creating_converter_for_unknown_format())
                .Then(x => Then_an_argument_exception_should_be_thrown())
                .BDDfy("Unsupported format throws", reporters);
        }

        // --- Scenario: Null format throws ArgumentNullException ---
        public void Given_null_format()
        {
            _format = null;
        }

        public void When_creating_converter_with_null_format()
        {
            try
            {
                _converter = DocumentConverterFactory.CreateDocumentConverter(_format);
            }
            catch (Exception ex)
            {
                _caughtException = ex;
            }
        }

        public void Then_argument_null_exception_is_thrown()
        {
            Assert.NotNull(_caughtException);
            Assert.IsType<ArgumentNullException>(_caughtException);
        }

        [Fact]
        public void Null_Format_Should_Throw_ArgumentNullException()
        {
            var reporters = new IReport[] { new HtmlReporter { ReportsDirectory = "reports/bdd", ReportName = "Null Format" } };
            this.Given(x => Given_null_format())
                .When(x => When_creating_converter_with_null_format())
                .Then(x => Then_argument_null_exception_is_thrown())
                .BDDfy("Null format throws", reporters);
        }
    }
}
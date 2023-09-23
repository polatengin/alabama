using System.Collections.Immutable;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

[DiagnosticAnalyzer(LanguageNames.CSharp)]
public class CustomAnalyzer : DiagnosticAnalyzer
{
    public const string DiagnosticId = "PRY0001";
    private const string Category = "Documentation";

    private static readonly DiagnosticDescriptor Rule = new DiagnosticDescriptor(
        DiagnosticId,
        "Missing XML Documentation",
        "Methods should have XML documentation comments",
        Category,
        DiagnosticSeverity.Warning,
        isEnabledByDefault: true);

    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics
    {
        get
        {
            // Define the diagnostic descriptor(s) supported by your analyzer
            return ImmutableArray.Create(Rule);
        }
    }

    public override void Initialize(AnalysisContext context)
    {
        context.RegisterSyntaxNodeAction(AnalyzeMethod, SyntaxKind.MethodDeclaration);
    }

    private static void AnalyzeMethod(SyntaxNodeAnalysisContext context)
    {
        var methodDeclaration = (MethodDeclarationSyntax)context.Node;

        // Check if the method lacks XML documentation
        if (!HasXmlDocumentation(methodDeclaration))
        {
            var diagnostic = Diagnostic.Create(Rule, methodDeclaration.GetLocation());
            context.ReportDiagnostic(diagnostic);
        }
    }

    private static bool HasXmlDocumentation(MethodDeclarationSyntax method)
    {
        // Implement your logic to check for XML documentation here
        // Return true if it has XML documentation, false otherwise
        return false; // Replace with your logic
    }
}

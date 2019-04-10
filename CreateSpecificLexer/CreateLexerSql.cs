#region License
/*
MIT License

Copyright (c) 2019 Petteri Kautonen

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
#endregion

using ScintillaNET;
using static VPKSoft.ScintillaLexers.LexerEnumerations;

namespace VPKSoft.ScintillaLexers.CreateSpecificLexer
{
    /// <summary>
    /// A class for the SQL lexer.
    /// Implements the <see cref="VPKSoft.ScintillaLexers.CreateSpecificLexer.CreateLexerCommon" />
    /// </summary>
    /// <seealso cref="VPKSoft.ScintillaLexers.CreateSpecificLexer.CreateLexerCommon" />
    public class CreateLexerSql: CreateLexerCommon
    {
        /// <summary>
        /// Creates the lexer for a given Scintilla class instance for the Structured Query Language (SQL).
        /// </summary>
        /// <param name="scintilla">A Scintilla class instance to set the lexer style for.</param>
        /// <param name="lexerColors">A <see cref="LexerColors"/> class instance for the lexer coloring.</param>
        /// <returns>True if the operation was successful; otherwise false.</returns>
        public static bool CreateSqlLexer(Scintilla scintilla, LexerColors lexerColors)
        {
            ClearStyle(scintilla);

            // KEYWORD, fontStyle = 1 
            scintilla.Styles[Style.Sql.Word].Bold = true;
            scintilla.Styles[Style.Sql.Word].ForeColor = lexerColors[LexerType.SQL, "WordFore"];
            scintilla.Styles[Style.Sql.Word].BackColor = lexerColors[LexerType.SQL, "WordBack"];

            // NUMBER, fontStyle = 0 
            scintilla.Styles[Style.Sql.Number].ForeColor = lexerColors[LexerType.SQL, "NumberFore"];
            scintilla.Styles[Style.Sql.Number].BackColor = lexerColors[LexerType.SQL, "NumberBack"];

            // STRING, fontStyle = 0 
            scintilla.Styles[Style.Sql.String].ForeColor = lexerColors[LexerType.SQL, "StringFore"];
            scintilla.Styles[Style.Sql.String].BackColor = lexerColors[LexerType.SQL, "StringBack"];

            // STRING2, fontStyle = 0 
            scintilla.Styles[Style.Sql.Character].ForeColor =
                lexerColors[LexerType.SQL, "CharacterFore"];
            scintilla.Styles[Style.Sql.Character].BackColor =
                lexerColors[LexerType.SQL, "CharacterBack"];

            // OPERATOR, fontStyle = 1 
            scintilla.Styles[Style.Sql.Operator].Bold = true;
            scintilla.Styles[Style.Sql.Operator].ForeColor =
                lexerColors[LexerType.SQL, "OperatorFore"];
            scintilla.Styles[Style.Sql.Operator].BackColor =
                lexerColors[LexerType.SQL, "OperatorBack"];

            // COMMENT, fontStyle = 0 
            scintilla.Styles[Style.Sql.Comment].ForeColor = lexerColors[LexerType.SQL, "CommentFore"];
            scintilla.Styles[Style.Sql.Comment].BackColor = lexerColors[LexerType.SQL, "CommentBack"];

            // COMMENT LINE, fontStyle = 0 
            scintilla.Styles[Style.Sql.CommentLine].ForeColor =
                lexerColors[LexerType.SQL, "CommentLineFore"];
            scintilla.Styles[Style.Sql.CommentLine].BackColor =
                lexerColors[LexerType.SQL, "CommentLineBack"];

            scintilla.Lexer = Lexer.Sql;

            // Name: instre1
            // self added: autoincrement..
            scintilla.SetKeywords(0,
                "abs absolute access acos add add_months adddate admin after aggregate all allocate alter and any app_name are array as asc ascii asin assertion at atan atn2 audit authid authorization autonomous_transaction avg before begin benchmark between bfilename bigint bin binary binary_checksum binary_integer bit bit_count bit_and bit_or blob body boolean both breadth bulk by call cascade cascaded case cast catalog ceil ceiling char char_base character charindex chartorowid check checksum checksum_agg chr class clob close cluster coalesce col_length col_name collate collation collect column comment commit completion compress concat concat_ws connect connection constant constraint constraints constructorcreate contains containsable continue conv convert corr corresponding cos cot count count_big covar_pop covar_samp create cross cube cume_dist current current_date current_path current_role current_time current_timestamp current_user currval cursor cycle data datalength databasepropertyex date date_add date_format date_sub dateadd datediff datename datepart datetime day db_id db_name deallocate dec declare decimal decode default deferrable deferred degrees delete dense_rank depth deref desc describe descriptor destroy destructor deterministic diagnostics dictionary disconnect difference distinct do domain double drop dump dynamic each else elsif empth encode encrypt end end-exec equals escape every except exception exclusive exec execute exists exit exp export_set extends external extract false fetch first first_value file float floor file_id file_name filegroup_id filegroup_name filegroupproperty fileproperty for forall foreign format formatmessage found freetexttable from from_days fulltextcatalog fulltextservice function general get get_lock getdate getansinull getutcdate global go goto grant greatest group grouping having heap hex hextoraw host host_id host_name hour ident_incr ident_seed ident_current identified identity if ifnull ignore immediate in increment index index_col indexproperty indicator initcap initial initialize initially inner inout input insert instr instrb int integer interface intersect interval into is is_member is_srvrolemember is_null is_numeric isdate isnull isolation iterate java join key lag language large last last_day last_value lateral lcase lead leading least left len length lengthb less level like limit limited ln lpad local localtime localtimestamp locator lock log log10 long loop lower ltrim make_ref map match max maxextents merge mid min minus minute mlslabel mod mode modifies modify module month months_between names national natural naturaln nchar nclob new new_time newid next next_day nextval no noaudit nocompress nocopy none not nowait null nullif number number_base numeric nvl nvl2 nvarchar object object_id object_name object_property ocirowid oct of off offline old on online only opaque open operator operation option or ord order ordinalityorganization others out outer output package pad parameter parameters partial partition path pctfree percent_rank pi pls_integer positive positiven postfix pow power pragma precision prefix preorder prepare preserve primary prior private privileges procedure public radians raise rand range rank ratio_to_export raw rawtohex read reads real record recursive ref references referencing reftohex relative release release_lock rename repeat replace resource restrict result return returns reverse revoke right rollback rollup round routine row row_number rowid rowidtochar rowlabel rownum rows rowtype rpad rtrim savepoint schema scroll scope search second section seddev_samp select separate sequence session session_user set sets share sign sin sinh size smallint some soundex space specific specifictype sql sqlcode sqlerrm sqlexception sqlstate sqlwarning sqrt start state statement static std stddev stdev_pop strcmp structure subdate substr substrb substring substring_index subtype successful sum synonym sys_context sys_guid sysdate system_user table tan tanh temporary terminate than then time timestamp timezone_abbr timezone_minute timezone_hour timezone_region tinyint to to_char to_date to_days to_number to_single_byte trailing transaction translate translation treat trigger trim true trunc truncate type ucase uid under union unique uniqueidentifier unknown unnest update upper usage use user userenv using validate value values var_pop var_samp varbinary varchar varchar2 variable variance varying view vsize when whenever where with without while work write year zone autoincrement");

            LexerFoldProperties.SetScintillaProperties(scintilla, LexerFoldProperties.SqlFolding);

            AddFolding(scintilla);
            return true;
        }
    }
}

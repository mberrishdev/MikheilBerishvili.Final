using System.Collections.Generic;
using System.Linq;
using MikheilBerishvili.Final.Domain.Validators;

namespace MikheilBerishvili.Final.Domain.Exceptions;

public class CommandValidationException : DomainException
{
    public CommandValidationException(IEnumerable<CommandValidationError> messages) : base(
        messages.Select(x => x.ErrorMessage))
    {
    }
}
# Explication

This module extends [Elucidation](./Elucidation.md) to define how to

- translate
- detect

`Value`.

## Dependencies

This module depends on [Elucidation](./Elucidation.md).

## Architecture

| Word | Abstraction |
|:-----------|:------------|
| Note | `Value` to describe other `Value`. |
| Translation | Converts `Value` to `Note`. |
| Condition | Criteria to detect. |
| Notice | `Value` to send when `Condition` is satisfied by other `Value`. |

This module enables developers to

- translate `Value` to `Note`.
- detect `Notice` of `Value`.

## Implementation

Nothing except internal implementation for some interfaces of [Elucidation](./Elucidation.md), because this module only defines how to

- translate
- detect

`Value`.
